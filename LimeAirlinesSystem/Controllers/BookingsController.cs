namespace LimeAirlinesSystem.Controllers
{
    using AutoMapper;
    using LimeAirlinesSystem.Data.Models;
    using LimeAirlinesSystem.Infrastructure.Extensions;
    using LimeAirlinesSystem.Models;
    using LimeAirlinesSystem.Models.Bookings;
    using LimeAirlinesSystem.Models.Flights;
    using LimeAirlinesSystem.Services.Bookings;
    using LimeAirlinesSystem.Services.Flights;
    using LimeAirlinesSystem.Services.Home;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
    using static WebConstants;

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
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public JsonResult Book([FromBody] int id, int countOfSeats)
        {
            var endLocation = this.bookings.Book(id, countOfSeats, this.User.Id());

            return Json(endLocation);
        }


        //[Authorize]
        //public IActionResult Book(
        //    int id, 
        //    int countOfSeats, 
        //    string tripType,
        //    string startLocation,
        //    string endLocation,
        //    DateTime? flightDate,
        //    int maxTransfers,
        //    int maxPrice,
        //    FlightSorting sorting)
        //{
        //    this.bookings.Book(id, countOfSeats, this.User.Id());

        //    TempData[GlobalMessageKey] = "Flight has been added to your bookings!";

        //    //var query = new HomeServiceModel
        //    //{
        //    //    FlightsQuery = new AllFlightsQueryModel
        //    //    {
        //    //        TripType = tripType,
        //    //        StartLocation = startLocation,
        //    //        EndLocation = endLocation,
        //    //        FlightDate = flightDate,
        //    //        MaxTransfers = maxTransfers,
        //    //        MaxPrice = maxPrice,
        //    //        Sorting = sorting,
        //    //        Passangers = countOfSeats
        //    //    }
        //    //};

        //    //return RedirectToAction(nameof(UserBookings));
        //    return RedirectToAction("Index","Home");

        //}

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
