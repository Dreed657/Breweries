using Breweries.Admin.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breweries.Admin.Controllers
{
    public class CitiesController : Controller
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
