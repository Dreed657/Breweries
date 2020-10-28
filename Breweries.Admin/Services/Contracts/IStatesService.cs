using Breweries.Admin.ViewModels;
using System.Collections.Generic;

namespace Breweries.Admin.Services.Contracts
{
    public interface IStatesService
    {
        IEnumerable<StateViewModel> GetAll(int count);
    }
}
