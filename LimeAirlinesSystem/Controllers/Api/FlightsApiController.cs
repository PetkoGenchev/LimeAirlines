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
                query.FlightDate,
                query.StartLocation,
                query.EndLocation,
                query.Passangers,
                query.TripType,
                query.MaxPrice,
                query.MaxTransfers,
                query.Sorting,
                query.CurrentPage,
                query.FlightsPerPage);

    }
}
