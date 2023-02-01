namespace LimeAirlinesSystem.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using LimeAirlinesSystem.Services.Flights;
    using LimeAirlinesSystem.Services.Flights.Models;
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

        public IActionResult Index()
        {

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
            return View(cheapestFlights);

            //return this.RedirectToAction("All","Flights",new {model = FilteredFlightsQueryModel{})
        }

        public IActionResult Error() => View();
    }
}