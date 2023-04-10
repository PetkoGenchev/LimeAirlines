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
        public IActionResult UserBookings()
        {
            var myFlights = this.flights.UserBookings(this.User.Id());

            return View(myFlights);
        }

        [Authorize]
        public IActionResult Book(int id, int countOfSeats)
        {
            this.flights.Book(id, countOfSeats, this.User.Id());

            return RedirectToAction(nameof(UserBookings));
            //return RedirectToAction("Index","Home", new { area = "" });

        }

        [Authorize]
        public IActionResult Cancel(string bookingId)
        {
            this.flights.CancelBooking(bookingId);

            return RedirectToAction(nameof(UserBookings));
        }
    }
}