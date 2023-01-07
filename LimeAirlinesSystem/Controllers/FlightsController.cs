namespace LimeAirlinesSystem.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using LimeAirlinesSystem.Data;
    using LimeAirlinesSystem.Data.Models;
    using LimeAirlinesSystem.Models.Flights;
    using LimeAirlinesSystem.Models.Home;
    using LimeAirlinesSystem.Services.Planes.Models;
    using Microsoft.AspNetCore.Mvc;

    public class FlightsController : Controller
    {
        private readonly AirlineDbContext data;

        public FlightsController(AirlineDbContext data)
            => this.data = data;


        public IActionResult Add() => View(new FlightFormModel
        {
            Planes = this.GetFlightData()
        });


        [HttpPost]
        public IActionResult Add(FlightFormModel flight)
        {
            if (!this.data.Planes.Any(p => p.Id == flight.PlaneId))
            {
                this.ModelState.AddModelError(nameof(flight.PlaneId), "This plane does not exist");
            }

            if (!ModelState.IsValid)
            {
                flight.Planes = this.GetPlaneData();

                return View(flight);
            }

            var flightAdd = new Flight
            {
                StartLocation = flight.StartLocation,
                EndLocation = flight.EndLocation,
                FlightStartDate = flight.FlightStartDate,
                FlightEndDate = flight.FlightEndDate,
                PlaneId = flight.PlaneId,
                Price = flight.Price,
                ImageUrl = flight.ImageUrl
                
            };

            this.data.Flights.Add(flightAdd);

            this.data.SaveChanges();

            return View(); /*RedirectToAction(nameof(All));*/

        }

        private IEnumerable<PlaneServiceModel> GetPlaneData()
        => this.data
            .Planes
            .Select(p => new PlaneServiceModel
            {
                Id = p.Id,
                Brand = p.Brand,
                Model = p.Model,
                Year = p.Year
            })
            .ToList();


        // NEED A GET AND POST METHOD FOR "FilteredFlights"


    }
}
