using Breweries.Admin.ViewModels;
using System.Collections.Generic;

namespace Breweries.Admin.Services.Contracts
{
    public interface IBreweryTypeService
    {
        IEnumerable<BreweyTypeViewModel> GetAll();
    }
}
