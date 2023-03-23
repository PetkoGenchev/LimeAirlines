namespace LimeAirlinesSystem.Areas.Admin.Controllers
{
    using AutoMapper;
    using LimeAirlinesSystem.Infrastructure.Extensions;
    using LimeAirlinesSystem.Models.Flights;
    using LimeAirlinesSystem.Services.Flights;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.CodeAnalysis.Differencing;
    using Microsoft.VisualBasic;
    using System;

    public class FlightsController : AdminController
    {
        private readonly IFlightService flights;
        private readonly IMapper mapper;

        public FlightsController(IFlightService flights, IMapper mapper)
        {
            this.flights = flights;
            this.mapper = mapper;
        }

        public IActionResult All()
        {
            var flights = this.flights
                .All()
                .Flights;

            return View(flights);
        }

        public IActionResult ChangeVisibility(int id)
        {
            this.flights.ChangeVisibility(id);

            return RedirectToAction(nameof(All));
        }



        public IActionResult Add()
        {
            return View(new FlightFormModel
            {
                Planes = this.flights.AllPlanes()
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(FlightFormModel flight)
        {
            if (!this.flights.PlaneExists(flight.PlaneId))
            {
                this.ModelState.AddModelError(nameof(flight.PlaneId), "Plane does not exist");
            }

            if (!ModelState.IsValid)
            {
                flight.Planes = this.flights.AllPlanes();

                return View(flight);
            }

            var flightId = this.flights.Create(
                flight.StartLocation,
                flight.EndLocation,
                flight.FlightDate,
                flight.Price,
                flight.ImageUrl,
                flight.PlaneId);

            return RedirectToAction(nameof(All));
        }



        [Authorize]
        public IActionResult Edit(int id)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            var flight = this.flights.Details(id);

            var flightForm = this.mapper.Map<FlightFormModel>(flight);

            flightForm.Planes = this.flights.AllPlanes();

            return View(flightForm);
        }

        [HttpPost]
        [Authorize]

        public IActionResult Edit(int id, FlightFormModel flight)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            if (!this.flights.PlaneExists(flight.PlaneId))
            {
                this.ModelState.AddModelError(nameof(flight.PlaneId), "Plane does not exist");
            }

            if (!ModelState.IsValid)
            {
                flight.Planes = this.flights.AllPlanes();

                return View(flight);
            }

            var edited = this.flights.Edit(
                id,
                flight.StartLocation,
                flight.EndLocation,
                flight.FlightDate,
                flight.Price,
                flight.ImageUrl,
                flight.PlaneId,
                this.User.IsAdmin());

            if (!edited)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));

        }
    }
}
