namespace LimeAirlinesSystem.Controllers
{
    using AutoMapper;
    using LimeAirlinesSystem.Data.Models;
    using LimeAirlinesSystem.Infrastructure.Extensions;
    using LimeAirlinesSystem.Models.Bookings;
    using LimeAirlinesSystem.Models.Flights;
    using LimeAirlinesSystem.Services.Bookings;
    using LimeAirlinesSystem.Services.Flights;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Book(int id, int countOfSeats)
        {
            this.bookings.Book(id, countOfSeats, this.User.Id());

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

            var bookingForm = this.mapper.Map<BookingFormModel>(bookings);

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
    }
}
