using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TTSSLib.Interfaces;
using TTSSWeb.Models;

namespace TTSSWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly IPassageService passageService;
        public TripsController(IPassageService passageService)
        {
            this.passageService = passageService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<TripPassages> Passages(string tripId)
        {
            return TripPassages.FromLibModel(await this.passageService.GetPassagesByTripId(tripId));
        }
    }
}