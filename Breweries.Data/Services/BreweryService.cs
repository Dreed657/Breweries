using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Breweries.Data.Models;
using Breweries.Importer.DTO;

namespace Breweries.Data.Services
{
    public class BreweryService : IBreweryService
    {
        private readonly ApplicationDbContext db;

        public BreweryService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Brewery> GetAllByCount(int count)
        {
            return this.db.Breweries.Take(count).ToList();
        }

        public async Task<Brewery> Create(RawBreweryDTO model)
        {
            var entity = new Brewery()
            {
                Name = model.name,
                PostalCode = model.postal_code,
                Url = model.website_url,
                Street = model.street,
                BreweryTypeId = await this.GetOrCreateBreweryType(model.brewery_type),
                StateId = await this.GetOrCreateState(model.state),
                CityId = await this.GetOrCreateCity(model.city),
            };

            Console.WriteLine($"Name: {entity.Name}");

            return entity;
        }

        public async Task CreateBulk(RawBreweryDTO[] models)
        {
            var entities = new List<Brewery>();

            foreach (var entity in models)
            {
                try
                {
                    entities.Add(await this.Create(entity));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            await this.SavaChanges(entities.ToArray());
        }

        private async Task<int> GetOrCreateCity(string type)
        {
            var entity = this.db.Cities.FirstOrDefault(x => x.Name == type);

            if (entity == null)
            {
                var model = new City() { Name = type };
                this.db.Cities.Add(model);
                await this.db.SaveChangesAsync();

                return model.Id;
            }
            else
            {
                return entity.Id;
            }
        }

        private async Task<int> GetOrCreateState(string type)
        {
            var entity = this.db.States.FirstOrDefault(x => x.Name == type);

            if (entity == null)
            {
                var model = new State() { Name = type };
                this.db.States.Add(model);
                await this.db.SaveChangesAsync();

                return model.Id;
            }
            else
            {
                return entity.Id;
            }
        }

        private async Task<int> GetOrCreateBreweryType(string type)
        {
            var entity = this.db.BreweryTypes.FirstOrDefault(x => x.Name == type);

            if (entity == null)
            {
                var model = new BreweryType() { Name = type };
                this.db.BreweryTypes.Add(model);
                await this.db.SaveChangesAsync();

                return model.Id;
            }
            else
            {
                return entity.Id;
            }
        }

        private async Task SavaChanges(Brewery[] models)
        {
            this.db.Breweries.AddRange(models);
            await this.db.SaveChangesAsync();
        }
    }
}
