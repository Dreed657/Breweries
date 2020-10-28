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

        public IActionResult Index()
        {
            var models = this.statesService.GetAll();
            return this.View(models);
        }
    }
}
