using System.Linq;
using System.Collections.Generic;

using Breweries.Data;
using Breweries.Services.Contracts;
using Breweries.Services.ViewModels;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Breweries.Services
{
    public class StatesService : IStatesService
    {
        private readonly ApplicationDbContext db;

        public StatesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool Delete(int Id)
        {
            var entity = this.db.States.FirstOrDefault(x => x.Id == Id);

            if (entity == null)
            {
                return false;
            }

            this.db.States.Remove(entity);
            this.db.SaveChanges();

            return true;
        }

        public bool Edit(int Id, string Name)
        {
            var entity = this.db.States.FirstOrDefault(x => x.Id == Id);

            if (entity == null)
            {
                return false;
            }

            entity.Name = Name;
            this.db.SaveChanges();

            return true;
        }

        public StateViewModel GetById(int Id)
        {
            return this.db.States
                .Where(x => x.Id == Id)
                .Select(x => new StateViewModel(x.Id, x.Name))
                .FirstOrDefault();
        }

        public IEnumerable<StateViewModel> GetAllByCount(int count)
        {
            return this.db.States
                .Select(x => new StateViewModel(x.Id, x.Name))
                .Take(count)
                .ToList();
        }

        public async Task<IEnumerable<StateViewModel>> GetAllAsync()
        {
            return await this.db.States
                .Select(x => new StateViewModel(x.Id, x.Name))
                .ToListAsync();
        }

        public int GetIdByName(string name)
        {
            return this.db.States.Where(x => x.Name == name).Select(x => x.Id).FirstOrDefault();
        }

        public IEnumerable<StateViewModel> GetAll()
        {
            return this.db.States
                .Select(x => new StateViewModel(x.Id, x.Name))
                .ToList();
        }
    }
}
