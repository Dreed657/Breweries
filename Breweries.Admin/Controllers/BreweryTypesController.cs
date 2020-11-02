using Microsoft.AspNetCore.Mvc;

using Breweries.Services.Contracts;
using System.Threading.Tasks;

namespace Breweries.Admin.Controllers
{
    [Route("BreweriesTypes")]
    public class BreweryTypesController : BaseController
    {
        private readonly IBreweryTypeService breweryTypeService;

        public BreweryTypesController(IBreweryTypeService breweryTypeService)
        {
            this.breweryTypeService = breweryTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var models = await this.breweryTypeService.GetAllAsync();
            return this.View(models);
        }

        [HttpGet("Edit")]
        public IActionResult Edit(int id)
        {
            var model = this.breweryTypeService.GetById(id);
            return this.View(model);
        }

        [HttpPost("Edit")]
        public IActionResult Edit(int id, string name)
        {
            if (!this.breweryTypeService.Edit(id, name))
            {
                return this.BadRequest("Model didn't update!");
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            this.breweryTypeService.Delete(id);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
