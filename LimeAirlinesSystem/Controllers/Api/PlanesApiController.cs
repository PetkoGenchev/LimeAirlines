using LimeAirlinesSystem.Models.Api.Flights;
using LimeAirlinesSystem.Services.Flights.Models;
using LimeAirlinesSystem.Services.Flights;
using Microsoft.AspNetCore.Mvc;
using LimeAirlinesSystem.Services.Planes;
using LimeAirlinesSystem.Models.Api.Planes;
using LimeAirlinesSystem.Services.Planes.Models;

namespace LimeAirlinesSystem.Controllers.Api
{
    [ApiController]
    [Route("api/planes")]
    public class PlanesApiController : ControllerBase
    {
        private readonly IPlaneService planes;

        public PlanesApiController(IPlaneService planes)
            => this.planes = planes;

        [HttpGet]
        public PlaneQueryServiceModel All([FromQuery] AllPlanesApiRequestModel query)
            => this.planes.All(
                query.CurrentPage,
                query.PlanesPerPage);
    }
}
