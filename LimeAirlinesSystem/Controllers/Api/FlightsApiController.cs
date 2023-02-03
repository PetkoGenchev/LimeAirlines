using LimeAirlinesSystem.Models.Api.Flights;
using LimeAirlinesSystem.Services.Flights;
using LimeAirlinesSystem.Services.Flights.Models;
using Microsoft.AspNetCore.Mvc;

namespace LimeAirlinesSystem.Controllers.Api
{

    [ApiController]
    [Route("api/flights")]
    public class FlightsApiController : ControllerBase
    {
        private readonly IFlightService flights;

        public FlightsApiController(IFlightService flights) 
            => this.flights = flights;

        [HttpGet]
        public FlightQueryServiceModel All([FromQuery] AllFlightsApiRequestModel query)
            => this.flights.All(
                query.StartLocation,
                query.EndLocation,
                query.FlightDateTime,
                query.CurrentPage,
                query.TripType,
                query.Passangers);

        // WHY THERE ARE NO FLIGHTSPERPAGE
    }
}
