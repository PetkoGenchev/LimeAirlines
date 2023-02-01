namespace LimeAirlinesSystem.Controllers
{

    using AutoMapper;
    using LimeAirlinesSystem.Infrastructure.Extensions;
    using LimeAirlinesSystem.Models.Flights;
    using LimeAirlinesSystem.Services.Flights;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class FlightsController : Controller
    {
        private readonly IFlightService flights;
        private readonly IMapper mapper;

        public FlightsController(IFlightService flights, IMapper mapper)
        {
            this.flights = flights;
            this.mapper = mapper;
        }


        public IActionResult All([FromQuery] AllFlightsQueryModel query)
        {
            var queryResult = this.flights.All(
                query.StartLocation,
                query.EndLocation,
                query.FlightDateTime,
                query.Passangers,
                query.TripType,
                query.CurrentPage,
                AllFlightsQueryModel.FlightsPerPage);

            var flightLocations = this.flights.AllDestinations();

            query.Locations = flightLocations;
            query.TotalFlights = queryResult.TotalFlights;
            query.Flights = queryResult.Flights;

            return View(query);
            //return this.RedirectToAction("FilteredView", "Flights", new { model = FilteredFlightsQueryModel{ })
            //return RedirectToAction(nameof(FilteredView));
        }


        //public IActionResult FilteredView([FromQuery] FilteredFlightsQueryModel query)
        //{
        //    var queryResult = this.flights.FilteredView(
        //        query.DepartureTime,
        //        query.MaxPrice,
        //        query.CurrentPage,
        //        query.)
        //}





        [Authorize]
        public IActionResult MyFlights()
        {
            var myFlights = this.flights.UserFlights(this.User.Id());

            return View(myFlights);
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
                flight.FlightDateTime.ToString(),
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
                flight.FlightDateTime.ToString(),
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