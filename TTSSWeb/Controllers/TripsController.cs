using Microsoft.AspNetCore.Mvc;
using TTSSLib.Interfaces;

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
    }
}