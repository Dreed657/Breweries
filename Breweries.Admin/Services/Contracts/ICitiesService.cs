using Breweries.Admin.ViewModels;
using System.Collections.Generic;

namespace Breweries.Admin.Services.Contracts
{
    public interface ICitiesService
    {
        IEnumerable<CitiesViewModel> GetAll();
    }
}
