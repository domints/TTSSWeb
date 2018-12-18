using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TTSSLib.Interfaces;
using TTSSLib.Services;
using TTSSWeb.Models;

namespace TTSSWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StopsController : ControllerBase
    {
        private readonly IStopService stopService;
        private readonly IPassageService passageService;

        public StopsController(IStopService stopService, IPassageService passageService)
        {
            this.stopService = stopService;
            this.passageService = passageService;
        }

        [HttpGet]
        [Route("autocomplete")]
        public async Task<IEnumerable<StopBase>> Autocomplete(string q)
        {
            return (await this.stopService.GetCompletionFromService(q))
                .Select(s => new StopBase { Id = s.ID, Name = s.Name});
        }

        [HttpGet]
        [Route("passages")]
        public async Task<IEnumerable<PassageListItem>> Passages(int stopId)
        {
            var response = await this.passageService.GetPassagesByStopId(stopId);
            return response.OldPassages.Select(p => new PassageListItem(p, true))
                .Concat(response.ActualPassages.Select(p => new PassageListItem(p))).ToList();
        }
    }
}
