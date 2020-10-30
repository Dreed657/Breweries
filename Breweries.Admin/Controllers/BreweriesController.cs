using Microsoft.AspNetCore.Mvc;

using Breweries.Services.Contracts;

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
        public IActionResult Index(int count = 5)
        {
            var models = this.breweryService.GetAllByCount(count);
            return this.View(models);
        }

        [HttpGet("Edit")]
        public IActionResult Edit(string Id)
        {
            var model = this.breweryService.GetEditModel(Id);
            return this.View(model);
        }

        [HttpGet("Delete")]
        public IActionResult Delete(string Id)
        {
            this.breweryService.Delete(Id);
            return RedirectToAction(nameof(this.Index));
        }
    }
}
