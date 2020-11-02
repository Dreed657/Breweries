﻿using System.Collections.Generic;

using Breweries.Services.ViewModels.Brewery;

namespace Breweries.Services.Contracts
{
    public interface IBreweriesService
    {
        bool Edit(InputBreweryEditModel model);

        bool Delete(string Id);

        BreweryViewModel GetById(string Id);

        EditBreweryViewModel GetEditModel(string Id);

        IEnumerable<BreweryViewModel> GetAll();

        IEnumerable<BreweryViewModel> GetAllByCount(int count = 5);
    }
}
