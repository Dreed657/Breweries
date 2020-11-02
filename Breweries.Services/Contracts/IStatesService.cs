﻿using System.Collections.Generic;

using Breweries.Services.ViewModels;

namespace Breweries.Services.Contracts
{
    public interface IStatesService
    {
        IEnumerable<StateViewModel> GetAll();

        int GetIdByName(string name);

        IEnumerable<StateViewModel> GetAllByCount(int count);

        StateViewModel GetById(int Id);

        bool Delete(int Id);

        bool Edit(int Id, string Name);
    }
}
