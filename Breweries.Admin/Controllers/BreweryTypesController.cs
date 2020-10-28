using Breweries.Admin.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Breweries.Admin.Controllers
{
    public class BreweryTypesController : Controller
    {
        private readonly IBreweryTypeService breweryTypeService;

        public BreweryTypesController(IBreweryTypeService breweryTypeService)
        {
            this.breweryTypeService = breweryTypeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var models = this.breweryTypeService.GetAll();
            return this.View(models);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = this.breweryTypeService.GetById(id);
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, [FromForm]string name)
        {
            if (!this.breweryTypeService.Edit(id, name))
            {
                return this.BadRequest("Model didn't update!");
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            this.breweryTypeService.Delete(id);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
