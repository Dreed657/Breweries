using System.Collections.Generic;
using System.Threading.Tasks;
using Breweries.Services.ViewModels;

namespace Breweries.Services.Contracts
{
    public interface IBreweryTypeService
    {
        IEnumerable<BreweyTypeViewModel> GetAll();

        Task<IEnumerable<BreweyTypeViewModel>> GetAllAsync();

        int GetIdByName(string name);

        IEnumerable<BreweyTypeViewModel> GetAllByCount(int count);

        BreweyTypeViewModel GetById(int Id);

        bool Delete(int Id);

        bool Edit(int Id, string Name);
    }
}
