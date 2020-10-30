using System.Collections.Generic;

using Breweries.Services.ViewModels;

namespace Breweries.Services.Contracts
{
    public interface IBreweriesService
    {
        bool Edit(string Id, BreweryEditModel model);

        bool Delete(string Id);

        BreweryViewModel GetById(string Id);

        EditBreweryViewModel GetEditModel(string Id);

        IEnumerable<BreweryViewModel> GetAll();

        IEnumerable<BreweryViewModel> GetAllByCount(int count = 5);
    }
}
