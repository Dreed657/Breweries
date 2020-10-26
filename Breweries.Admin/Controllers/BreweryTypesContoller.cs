using Microsoft.AspNetCore.Mvc;

namespace Breweries.Admin.Controllers
{
    public class BreweryTypesContoller : Controller
    {
        public BreweryTypesContoller()
        {
        }

        public IActionResult Index(int count = 5)
        {
            return this.View();
        }
    }
}
