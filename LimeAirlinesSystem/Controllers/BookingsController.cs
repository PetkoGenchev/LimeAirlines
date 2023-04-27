namespace LimeAirlinesSystem.Controllers
{
    using AutoMapper;
    using LimeAirlinesSystem.Data.Models;
    using LimeAirlinesSystem.Infrastructure.Extensions;
    using LimeAirlinesSystem.Models.Bookings;
    using LimeAirlinesSystem.Models.Flights;
    using LimeAirlinesSystem.Services.Bookings;
    using LimeAirlinesSystem.Services.Flights;
    using LimeAirlinesSystem.Services.Home;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

    public class BookingsController : Controller
    {
        private readonly IBookingService bookings;
        private readonly IMapper mapper;

        public BookingsController(IBookingService bookings, IMapper mapper)
        {
            this.bookings = bookings;
            this.mapper = mapper;
        }

        [Authorize]
        public IActionResult UserBookings()
        {
            var myFlights = this.bookings.UserBookings(this.User.Id());

            return View(myFlights);
        }

        [Authorize]
        public IActionResult Book(int id, int countOfSeats/*, AllFlightsQueryModel queryModel*/)
        {
            this.bookings.Book(id, countOfSeats, this.User.Id());

            //var query = new HomeServiceModel
            //{
            //    FlightsQuery = queryModel
            //};

            //return RedirectToAction("Index", "Home",query);

            return RedirectToAction(nameof(UserBookings));

        }

        [Authorize]
        public IActionResult Cancel(string bookingId)
        {
            this.bookings.CancelBooking(bookingId);

            return RedirectToAction(nameof(UserBookings));
        }



        [Authorize]
        public IActionResult AddLuggage(string bookingId)
        {
            var booking = this.bookings.BookingDetails(bookingId);

            var bookingForm = this.mapper.Map<BookingFormModel>(booking);

            return View(bookingForm);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddLuggage(string bookingId, BookingFormModel booking)
        {
            var edited = this.bookings.AddLuggage(
                bookingId,
                booking.SmallLuggage,
                booking.MediumLuggage,
                booking.LargeLuggage);

            if (!edited)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(UserBookings));

        }

        public IActionResult CancelAddLuggage()
        {
            return RedirectToAction(nameof(UserBookings));
        }


        public IActionResult CheckIn(string bookingId)
        {
            this.bookings.CheckIn(bookingId);

            return RedirectToAction(nameof(UserBookings));
        }
    }
}
