using Breweries.Admin.Services.Contracts;
using Breweries.Admin.ViewModels;
using Breweries.Data;
using System.Collections.Generic;
using System.Linq;

namespace Breweries.Admin.Services
{
    public class StatesService : IStatesService
    {
        private readonly ApplicationDbContext db;

        public StatesService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<StateViewModel> GetAll()
        {
            return this.db.Cities
                .Select(x => new StateViewModel(x.Id, x.Name))
                .ToList();
        }
    }
}
