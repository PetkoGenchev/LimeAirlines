namespace LimeAirlinesSystem.Services.Bookings
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using LimeAirlinesSystem.Data;
    using LimeAirlinesSystem.Data.Models;
    using LimeAirlinesSystem.Services.Bookings.Models;
    using System.Collections.Generic;
    using System.Linq;
    using static LimeAirlinesSystem.Data.DataConstants;
    public class BookingService : IBookingService
    {
        private readonly AirlineDbContext data;
        private readonly IConfigurationProvider mapper;

        public BookingService(AirlineDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper.ConfigurationProvider;
        }

        public string Book(int flightId, int countOfSeats, string userId)
        {
            var flight = this.data.Flights.Find(flightId);
            var planeSeats = this.data.Planes.Where(x => x.Id == flight.PlaneId).Select(x => x.NumberOfSeats).FirstOrDefault();

            var booking = new FlightBooking
            {
                FlightId = flightId,
                CountOfSeats = countOfSeats,
                UserId = userId,
                TotalPrice = flight.Price,
                ImageUrl = flight.ImageUrl               
            };

            flight.ReservedSeats += countOfSeats;

            if (flight.ReservedSeats == planeSeats)
            {
                flight.IsPublic = false;
            }

            this.data.FlightBookings.Add(booking);
            this.data.SaveChanges();

            return flight.EndLocation;
        }

        public FlightBookingServiceModel BookingDetails(string bookingId)
            => this.data
            .FlightBookings
            .Where(f => f.Id == bookingId)
            .ProjectTo<FlightBookingServiceModel>(this.mapper)
            .FirstOrDefault();

        public void CancelBooking(string bookingId)
        {
            var booking = this.data.FlightBookings.Where(x => x.Id == bookingId).FirstOrDefault();

            var removeSeatsFlight = this.data.Flights.Where(x => x.Id == booking.FlightId).FirstOrDefault();

            removeSeatsFlight.ReservedSeats -= booking.CountOfSeats;

            removeSeatsFlight.IsPublic = true;

            booking.IsCancelled = true;

            this.data.SaveChanges();
        }

        public IEnumerable<FlightBookingServiceModel> UserBookings(string userId)
            => this.data
                .FlightBookings
                .Where(u => u.UserId == userId)
                .ProjectTo<FlightBookingServiceModel>(this.mapper)
                .ToList();

        public bool AddLuggage(
            string bookingId,
            int smallLuggage,
            int mediumLuggage,
            int largeLuggage)
        {
            var bookingData = this.data.FlightBookings.Find(bookingId);

            if (bookingData == null)
            {
                return false;
            }

            var flightInitialPrice = this.data.Flights.Where(x => x.Id == bookingData.FlightId).Select(p => p.Price).FirstOrDefault();

            bookingData.SmallLuggage = smallLuggage;
            bookingData.MediumLuggage = mediumLuggage;
            bookingData.LargeLuggage = largeLuggage;
            bookingData.TotalPrice = flightInitialPrice +
                smallLuggage * LuggageConstants.SmallLuggagePrice +
                mediumLuggage * LuggageConstants.MediumLuggagePrice +
                largeLuggage * LuggageConstants.LargeLuggagePrice;


            this.data.SaveChanges();

            return true;
        }

        public void CheckIn(string bookingId)
        {
            var booking = this.data.FlightBookings.Find(bookingId);

            booking.IsCheckedIn = true;

            this.data.SaveChanges();
        }
    }
}
