using Breweries.Admin.Services.Contracts;
using Breweries.Admin.ViewModels;
using Breweries.Data;
using System.Collections.Generic;
using System.Linq;

namespace Breweries.Admin.Services
{
    public class CitiesService : ICitiesService
    {
        private readonly ApplicationDbContext db;

        public CitiesService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<CitiesViewModel> GetAll(int count)
        {
            return this.db.Cities
                .Select(x => new CitiesViewModel(x.Id, x.Name))
                .Take(count)
                .ToList();
        }
    }
}
