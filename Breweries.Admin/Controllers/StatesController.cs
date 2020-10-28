using Breweries.Admin.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Breweries.Admin.Controllers
{
    public class StatesController : Controller
    {
        private readonly IStatesService statesService;

        public StatesController(IStatesService statesService)
        {
            this.statesService = statesService;
        }

        public IActionResult Index(int count = 5)
        {
            var models = this.statesService.GetAll(count);
            return this.View(models);
        }

        public IActionResult Edit(int id)
        {
            return this.RedirectToAction(nameof(this.Index));
        }

        public IActionResult Delete(int id)
        {
            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
