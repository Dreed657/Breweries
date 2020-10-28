﻿using Breweries.Admin.Services.Contracts;
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

        public bool Delete(int Id)
        {
            var entity = this.db.Cities.FirstOrDefault(x => x.Id == Id);

            if (entity == null)
            {
                return false;
            }

            this.db.Cities.Remove(entity);
            this.db.SaveChanges();

            return true;
        }

        public bool Edit(int Id, string Name)
        {
            var entity = this.db.Cities.FirstOrDefault(x => x.Id == Id);

            if (entity == null)
            {
                return false;
            }

            entity.Name = Name;
            this.db.SaveChanges();

            return true;
        }

        public CitiesViewModel GetById(int Id)
        {
            return this.db.Cities
                .Where(x => x.Id == Id)
                .Select(x => new CitiesViewModel(x.Id, x.Name))
                .FirstOrDefault();
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
