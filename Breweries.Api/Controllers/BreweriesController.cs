using Breweries.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Breweries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreweriesController : ControllerBase
    {
        private readonly IBreweriesService breweryService;

        public BreweriesController(IBreweriesService breweryService)
        {
            this.breweryService = breweryService;
        }

        [HttpGet]
        public IActionResult GetByCount(int count = 5)
        {
            var data = this.breweryService.GetAllByCount(count);

            return Ok(data);
        }
    }
}
