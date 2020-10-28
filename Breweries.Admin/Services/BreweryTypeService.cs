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

        public IEnumerable<BreweyTypeViewModel> GetAll()
        {
            return this.db.BreweryTypes
                .Select(x => new BreweyTypeViewModel(x.Id, x.Name))
                .ToList();
        }
    }
}
