namespace LimeAirlinesSystem.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using LimeAirlinesSystem.Data;
    using LimeAirlinesSystem.Data.Models;
    using LimeAirlinesSystem.Models.Flights;
    using LimeAirlinesSystem.Models.Home;
    using LimeAirlinesSystem.Models.Planes;
    using Microsoft.AspNetCore.Mvc;

    public class FlightsController : Controller
    {
        private readonly AirlineDbContext data;

        public FlightsController(AirlineDbContext data)
            => this.data = data;


        public IActionResult All()
        {
            var flights = this.data
                .Flights
                .OrderByDescending(f => f.Id)
                .Select(f => new FlightIndexViewModel
                {
                    Id = f.Id,
                    StartLocation = f.StartLocation,
                    EndLocation = f.EndLocation,
                    FlightStartDate = f.FlightStartDate.ToString(),
                    FlightEndDate = f.FlightEndDate.ToString(),
                    Price = f.Price,
                    ImageUrl = f.ImageUrl
                })
                .ToList();

            return View(flights);
        }


        public IActionResult Add() => View(new AddFlightFormModel
        {
            Planes = this.GetPlaneData()
        });


        [HttpPost]
        public IActionResult Add(AddFlightFormModel flight)
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

            return RedirectToAction(nameof(All));

        }

        private IEnumerable<PlaneListingViewModel> GetPlaneData()
        => this.data
            .Planes
            .Select(p => new PlaneListingViewModel
            {
                Id = p.Id,
                Brand = p.Brand,
                Model = p.Model,
                Year = p.Year
            })
            .ToList();
    }
}
