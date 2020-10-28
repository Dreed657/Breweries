using Breweries.Admin.Services.Contracts;
using Breweries.Admin.ViewModels;
using Breweries.Data;
using System.Collections.Generic;
using System.Linq;

namespace Breweries.Admin.Services
{
    public class BreweryTypeService : IBreweryTypeService
    {
        private readonly ApplicationDbContext db;

        public BreweryTypeService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool Delete(int Id)
        {
            var entity = this.db.BreweryTypes.FirstOrDefault(x => x.Id == Id);

            if (entity == null)
            {
                return false;
            }

            this.db.BreweryTypes.Remove(entity);
            this.db.SaveChanges();

            return true;
        }

        public bool Edit(int Id, string Name)
        {
            var entity = this.db.BreweryTypes.FirstOrDefault(x => x.Id == Id);

            if (entity == null)
            {
                return false;
            }

            entity.Name = Name;
            this.db.SaveChanges();

            return true;
        }

        public IEnumerable<BreweyTypeViewModel> GetAll()
        {
            return this.db.BreweryTypes
                .Select(x => new BreweyTypeViewModel(x.Id, x.Name))
                .ToList();
        }

        public BreweyTypeViewModel GetById(int Id)
        {
            return this.db.BreweryTypes
                .Where(x => x.Id == Id)
                .Select(x => new BreweyTypeViewModel(x.Id, x.Name))
                .FirstOrDefault();
        }
    }
}
