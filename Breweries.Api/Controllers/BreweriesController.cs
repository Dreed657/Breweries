using Breweries.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace Breweries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreweriesController : ControllerBase
    {
        private readonly IBreweryService breweryService;

        public BreweriesController(IBreweryService breweryService)
        {
            this.breweryService = breweryService;
        }

        [HttpGet]
        public IActionResult GetByCount(int count = 5)
        {
            return Ok(this.breweryService.GetAllByCount(count));
        }
    }
}
