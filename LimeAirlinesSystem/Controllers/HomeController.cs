namespace LimeAirlinesSystem.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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


        //-------------------------------------------

        public IActionResult Index([FromQuery] AllFlightsQueryModel query)
        {
            var queryResult = this.flights.All(
                query.StartLocation,
                query.EndLocation,
                query.FlightStartDateTime,
                query.FlightEndDateTime,
                query.Passangers,
                query.TripType,
                query.CurrentPage,
                AllFlightsQueryModel.FlightsPerPage);

            var flightLocations = this.flights.AllDestinations();

            query.Locations = flightLocations;
            query.TotalFlights = queryResult.TotalFlights;
            query.Flights = queryResult.Flights;

            //return View(query);

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

            //return View(cheapestFlights);

            //return this.RedirectToAction("All","Flights",new {model = FilteredFlightsQueryModel{})
        }


        //-------------------------------------------------



        //public IActionResult Index()
        //{

        //    var cheapestFlights = this.cache.Get<List<CheapestFlightServiceModel>>(CheapestFlightsCacheKey);

        //    if (cheapestFlights == null)
        //    {
        //        cheapestFlights = this.flights
        //            .Cheapest()
        //            .ToList();


        //        var cacheOptions = new MemoryCacheEntryOptions()
        //            .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));

        //        this.cache.Set(CheapestFlightsCacheKey, cheapestFlights, cacheOptions);
        //    }
        //    return View(cheapestFlights);

        //    //return this.RedirectToAction("All","Flights",new {model = FilteredFlightsQueryModel{})
        //}

        public IActionResult Error() => View();
    }
}