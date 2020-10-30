using System.Collections.Generic;

using Breweries.Services.ViewModels;

namespace Breweries.Services.Contracts
{
    public interface IBreweriesService
    {
        bool Edit(string Id, BreweryEditModel model);

        bool Delete(string Id);

        IEnumerable<BreweryViewModel> GetAll(int count = 5);
    }
}
