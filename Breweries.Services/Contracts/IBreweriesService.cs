using System.Collections.Generic;
using System.Threading.Tasks;
using Breweries.Services.ViewModels.Brewery;

namespace Breweries.Services.Contracts
{
    public interface IBreweriesService
    {
        bool Edit(InputBreweryEditModel model);

        bool Delete(string Id);

        BreweryViewModel GetById(string Id);

        EditBreweryViewModel GetEditModel(string Id);

        Task<IEnumerable<BreweryViewModel>> GetAllAsync(string query, string postalCode);

        IEnumerable<BreweryViewModel> GetAllByCount(int count = 5);
    }
}
