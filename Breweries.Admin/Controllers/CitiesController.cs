using Microsoft.AspNetCore.Mvc;

using Breweries.Services.Contracts;

namespace Breweries.Admin.Controllers
{
    [Route("Cities")]
    public class CitiesController : BaseController
    {
        private readonly ICitiesService citiesService;

        public CitiesController(ICitiesService citiesService)
        {
            this.citiesService = citiesService;
        }

        [HttpGet]
        public IActionResult Index(int count = 5)
        {
            var models = this.citiesService.GetAll(count);
            return View(models);
        }

        [HttpGet("Edit")]
        public IActionResult Edit(int id)
        {
            var model = this.citiesService.GetById(id);
            return this.View(model);
        }

        [HttpPost("Edit")]
        public IActionResult Edit(int id, string name)
        {
            if (!this.citiesService.Edit(id, name))
            {
                return this.BadRequest("Model didn't update!");
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            this.citiesService.Delete(id);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
