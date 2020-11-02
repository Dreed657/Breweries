using System.Collections.Generic;
using System.Threading.Tasks;
using Breweries.Services.ViewModels;

namespace Breweries.Services.Contracts
{
    public interface ICitiesService
    {
        IEnumerable<CitiesViewModel> GetAll();

        Task<IEnumerable<CitiesViewModel>> GetAllAsync();

        int GetIdByName(string name);

        IEnumerable<CitiesViewModel> GetAllByCount(int count);

        CitiesViewModel GetById(int Id);

        bool Delete(int Id);

        bool Edit(int Id, string Name);
    }
}
