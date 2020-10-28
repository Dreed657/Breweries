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
        public IEnumerable<StateViewModel> GetAll(int count)
        {
            return this.db.States
                .Select(x => new StateViewModel(x.Id, x.Name))
                .Take(count)
                .ToList();
        }
    }
}
