using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TTSSLib.Interfaces;
using TTSSLib.Models.Enums;
using TTSSLib.Services;
using TTSSWeb.Models;
using TTSSWeb.Services;

namespace TTSSWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StopsController : ControllerBase
    {
        private readonly IPassageService passageService;
        private readonly IAutocompleteService autocompleteService;
        private readonly IStopCacheService stopCacheService;

        public StopsController(
            IPassageService passageService,
            IAutocompleteService autocompleteService,
            IStopCacheService stopCacheService)
        {
            this.autocompleteService = autocompleteService;
            this.stopCacheService = stopCacheService;
            this.passageService = passageService;
        }

        [HttpGet]
        [Route("autocomplete")]
        public Task<ICollection<StopBase>> Autocomplete(string q)
        {
            return autocompleteService.GetAutocomplete(q);
        }

        [HttpGet]
        [Route("passages")]
        public async Task<IEnumerable<PassageListItem>> Passages(int stopId)
        {
            var response = await this.passageService.GetPassagesByStopId(stopId, StopPassagesType.Departure, stopCacheService.GetStopType(stopId));
            return response.OldPassages.Select(p => new PassageListItem(p, true))
                .Concat(response.ActualPassages.Select(p => new PassageListItem(p))).ToList();
        }
    }
}
