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

        public IActionResult Index()
        {
            var models = this.citiesService.GetAll();
            return View(models);
        }
    }
}
