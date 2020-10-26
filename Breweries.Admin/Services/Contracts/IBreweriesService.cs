using Breweries.Admin.ViewModels;
using System.Collections.Generic;

namespace Breweries.Admin.Services.Contracts
{
    public interface IBreweriesService
    {
        bool Edit(string Id, BreweryEditModel model);

        bool Delete(string Id);

        IEnumerable<BreweryViewModel> GetAll(int count = 5);
    }
}
