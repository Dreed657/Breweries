using System.Linq;
using System.Collections.Generic;

using Breweries.Data;
using Breweries.Services.Contracts;
using Breweries.Services.ViewModels.Brewery;
using System;
using Breweries.Data.Models;

namespace Breweries.Services
{
    public class BreweriesService : IBreweriesService
    {
        private readonly ApplicationDbContext db;
        private readonly ICitiesService citiesService;
        private readonly IStatesService statesService;
        private readonly IBreweryTypeService breweryTypeService;

        public BreweriesService(ApplicationDbContext db, ICitiesService citiesService, IStatesService statesService, IBreweryTypeService breweryTypeService)
        {
            this.db = db;
            this.citiesService = citiesService;
            this.statesService = statesService;
            this.breweryTypeService = breweryTypeService;
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

        public bool Edit(InputBreweryEditModel model)
        {
            // TODO: Add Validation for State City BreweryType ...

            var entity = this.db.Breweries.FirstOrDefault(x => x.Id == model.Id);

            if (entity == null)
            {
                return false;
            }

            entity.Name = model.Name;
            entity.Street = model.Street;
            entity.PostalCode = model.PostalCode;
            entity.StateId = this.statesService.GetIdByName(model.State);
            entity.CityId = this.citiesService.GetIdByName(model.City);
            entity.BreweryTypeId = this.breweryTypeService.GetIdByName(model.Status);
            entity.Url = model.Url;

            this.db.Breweries.Update(entity);
            this.db.SaveChanges();

            return true;
        }

        public EditBreweryViewModel GetEditModel(string Id)
        {
            return this.db.Breweries
                .Where(x => x.Id == Id)
                .Select(x => new EditBreweryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    PostalCode = x.PostalCode,
                    Street = x.Street,
                    City = x.City.Name,
                    State = x.State.Name,
                    Status = x.BreweryType.Name,
                    Url = x.Url,
                    Cities = this.citiesService.GetAll().Select(x => x.Name).ToList(),
                    States = this.statesService.GetAll().Select(x => x.Name).ToList(),
                    Statues = this.breweryTypeService.GetAll().Select(x => x.Name).ToList(),
                }).FirstOrDefault();
        }

        public IEnumerable<BreweryViewModel> GetAll()
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
                .ToList();
        }

        public IEnumerable<BreweryViewModel> GetAllByCount(int count = 5)
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

        public BreweryViewModel GetById(string Id)
        {
            return this.db.Breweries
                .Where(x => x.Id == Id)
                .Select(x => new BreweryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    BreweryTypeName = x.BreweryType.Name,
                    CityName = x.City.Name,
                    PostalCode = x.PostalCode,
                    StateName = x.State.Name,
                    Street = x.Street,
                    Url = x.Url,
                }).FirstOrDefault();
        }
    }
}
