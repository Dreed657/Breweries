﻿using Microsoft.AspNetCore.Mvc;

using Breweries.Services.Contracts;
using System.Threading.Tasks;

namespace Breweries.Admin.Controllers
{
    [Route("States")]
    public class StatesController : BaseController
    {
        private readonly IStatesService statesService;

        public StatesController(IStatesService statesService)
        {
            this.statesService = statesService;
        }

        public async Task<IActionResult> Index()
        {
            var models = await this.statesService.GetAllAsync();
            return this.View(models);
        }

        [HttpGet("Edit")]
        public IActionResult Edit(int id)
        {
            var model = this.statesService.GetById(id);
            return this.View(model);
        }

        [HttpPost("Edit")]
        public IActionResult Edit(int id, string name)
        {
            if (!this.statesService.Edit(id, name))
            {
                return this.BadRequest("Model didn't update!");
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            this.statesService.Delete(id);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
