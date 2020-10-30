using System.Linq;
using System.Collections.Generic;

using Breweries.Data;
using Breweries.Services.Contracts;
using Breweries.Services.ViewModels;

namespace Breweries.Services
{
    public class BreweriesService : IBreweriesService
    {
        private readonly ApplicationDbContext db;

        public BreweriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool Delete(string Id)
        {
            var entity = this.db.Breweries.FirstOrDefault(x => x.Id == Id);

            if (entity == null)
            {
                return false;
            }

            this.db.Breweries.Remove(entity);
            this.db.SaveChanges();

            return true;
        }

        public bool Edit(string Id, BreweryEditModel model)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<BreweryViewModel> GetAll(int count = 5)
        {
            return this.db.Breweries
                .Select(x => new BreweryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    BreweryTypeName = x.BreweryType.Name,
                    CityName = x.City.Name,
                    StateName = x.State.Name,
                    Street = x.Street,
                    PostalCode = x.PostalCode,
                    Url = x.Url,
                })
                .Take(count)
                .ToList();
        }
    }
}
