﻿using System.Collections.Generic;

using Breweries.Services.ViewModels;

namespace Breweries.Services.Contracts
{
    public interface IBreweryTypeService
    {
        IEnumerable<BreweyTypeViewModel> GetAll();

        BreweyTypeViewModel GetById(int Id);

        bool Delete(int Id);

        bool Edit(int Id, string Name);
    }
}