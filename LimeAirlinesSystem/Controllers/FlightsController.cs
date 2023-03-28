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


        [Authorize]
        public IActionResult UserFlights()
        {
            var myFlights = this.flights.UserFlights(this.User.Id());

            return View(myFlights);
        }

        [Authorize]
        public IActionResult Book(int flightId)
        {
            this.flights.Book(flightId);

            return RedirectToAction(nameof(UserFlights));
        }


        //[Authorize]
        //public IActionResult Cancel(int flightId)
        //{
        //    this.flights.CancelBooking(id);

        //    return RedirectToAction(nameof(MyFlights));
        //}
    }
}