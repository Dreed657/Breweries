using Breweries.Admin.ViewModels;
using System.Collections.Generic;

namespace Breweries.Admin.Services.Contracts
{
    public interface IBreweryTypeService
    {
        IEnumerable<BreweyTypeViewModel> GetAll();

        BreweyTypeViewModel GetById(int Id);

        bool Delete(int Id);

        bool Edit(int Id, string Name);
    }
}
