using Breweries.Admin.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Breweries.Admin.Controllers
{
    public class BreweryTypesController : Controller
    {
        private readonly IBreweryTypeService breweryTypeService;

        public BreweryTypesController(IBreweryTypeService breweryTypeService)
        {
            this.breweryTypeService = breweryTypeService;
        }

        public IActionResult Index()
        {
            var models = this.breweryTypeService.GetAll();
            return this.View(models);
        }
    }
}
