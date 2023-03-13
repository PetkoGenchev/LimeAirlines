namespace LimeAirlinesSystem.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using LimeAirlinesSystem.Infrastructure.Extensions;
    using LimeAirlinesSystem.Models.Flights;
    using LimeAirlinesSystem.Services.Flights;
    using LimeAirlinesSystem.Services.Flights.Models;
    using LimeAirlinesSystem.Services.Home;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using static WebConstants.Cache;

    public class HomeController : Controller
    {
        private readonly IFlightService flights;
        private readonly IMemoryCache cache;

        public HomeController(
            IFlightService flights,
            IMemoryCache cache)
        {
            this.flights = flights;
            this.cache = cache;
        }


        public IActionResult Index([FromQuery] AllFlightsQueryModel query)
        {

            var queryResult = this.flights.All(
                query.StartLocation,
                query.EndLocation,
                query.FlightDate,
                query.Passangers,
                query.TripType,
                query.MaxPrice,
                query.Sorting,
                query.CurrentPage,
                AllFlightsQueryModel.FlightsPerPage);



            var flightStartLocations = this.flights.AllStartingLocations();
            var flightEndLocations = this.flights.AllFinalLocations();

            var tripTypes = this.flights.AllTripTypes();

            query.TripTypes = tripTypes;

            query.StartLocations = flightStartLocations;
            query.EndLocations = flightEndLocations;

            query.TotalFlights = queryResult.TotalFlights;
            query.Flights = queryResult.Flights;

            var cheapestFlights = this.cache.Get<List<CheapestFlightServiceModel>>(CheapestFlightsCacheKey);

            if (cheapestFlights == null)
            {
                cheapestFlights = this.flights
                    .Cheapest()
                    .ToList();


                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));

                this.cache.Set(CheapestFlightsCacheKey, cheapestFlights, cacheOptions);
            }

            var homeService = new HomeServiceModel
            {
                CheapestFlight = cheapestFlights,
                QueryModel = query
            };

            return View(homeService);
        }

        public IActionResult Error() => View();
    }
}