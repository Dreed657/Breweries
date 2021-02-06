using Microsoft.AspNetCore.Mvc;

using Breweries.Services.Contracts;
using Breweries.Services.ViewModels.Brewery;
using System.Threading.Tasks;

namespace Breweries.Admin.Controllers
{
    [Route("Breweries")]
    public class BreweriesController : BaseController
    {
        private readonly IBreweriesService breweryService;

        public BreweriesController(IBreweriesService breweryService)
        {
            this.breweryService = breweryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string query, string postCode)
        {
            var models = await this.breweryService.GetAllAsync(query, postCode);
            return this.View(models);
        }

        [HttpGet("Edit")]
        public IActionResult Edit(string Id)
        {
            var model = this.breweryService.GetEditModel(Id);
            return this.View(model);
        }

        [HttpPost("Edit")]
        public IActionResult Edit(InputBreweryEditModel model)
        {
            if (ModelState.IsValid)
            {
                this.breweryService.Edit(model);
            }

            return RedirectToAction(nameof(this.Index));
        }

        [HttpGet("Delete")]
        public IActionResult Delete(string Id)
        {
            this.breweryService.Delete(Id);
            return RedirectToAction(nameof(this.Index));
        }
    }
}
