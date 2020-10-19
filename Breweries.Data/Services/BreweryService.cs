using Breweries.Data.Models;
using Breweries.Importer.DTO;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

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
                BreweryTypeId = this.GetOrCreateBreweryType(model.brewery_type),
                StateId = this.GetOrCreateState(model.state),
                CityId = this.GetOrCreateCity(model.city),
            };

            System.Console.WriteLine($"Name: {entity.Name}");

            return entity;
        }

        public async Task CreateBulk(RawBreweryDTO[] models)
        {
            var entities = new List<Brewery>();

            foreach (var entity in models)
            {
                entities.Add(await this.Create(entity));
            }

            await this.SavaChanges(entities.ToArray());
        }

        private int GetOrCreateCity(string type)
        {
            var entity = this.db.Cities.FirstOrDefault(x => x.Name == type);

            if (entity == null)
            {
                var model = new City() { Name = type };
                this.db.Cities.Add(model);

                return model.Id;
            }
            else
            {
                return entity.Id;
            }
        }

        private int GetOrCreateState(string type)
        {
            var entity = this.db.States.FirstOrDefault(x => x.Name == type);

            if (entity == null)
            {
                var model = new State() { Name = type };
                this.db.States.Add(model);

                return model.Id;
            }
            else
            {
                return entity.Id;
            }
        }

        private int GetOrCreateBreweryType(string type)
        {
            var entity = this.db.BreweryTypes.FirstOrDefault(x => x.Name == type);

            if (entity == null)
            {
                var model = new BreweryType() { Name = type };
                this.db.BreweryTypes.Add(model);

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
