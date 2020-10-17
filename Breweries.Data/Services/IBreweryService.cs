using Breweries.Data.Models;
using Breweries.Importer.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Breweries.Data.Services
{
    public interface IBreweryService
    {
        IEnumerable<Brewery> GetAllByCount(int count);

        Task<Brewery> Create(RawBreweryDTO model);

        Task CreateBulk(RawBreweryDTO[] models);
    }
}
