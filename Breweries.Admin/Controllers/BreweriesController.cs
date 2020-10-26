using Breweries.Admin.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Breweries.Admin.Controllers
{
    public class BreweriesController : Controller
    {
        private readonly IBreweriesService breweryService;

        public BreweriesController(IBreweriesService breweryService)
        {
            this.breweryService = breweryService;
        }

        [HttpGet]
        public IActionResult Index(int count = 5)
        {
            var models = this.breweryService.GetAll(count);
            return this.View(models);
        }

        [HttpGet("Edit")]
        public IActionResult Edit(string Id)
        {
            return this.View();
        }

        [HttpGet("Delete")]
        public IActionResult Delete(string Id)
        {
            this.breweryService.Delete(Id);
            return RedirectToAction(nameof(this.Index));
        }
    }
}
