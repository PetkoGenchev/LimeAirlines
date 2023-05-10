namespace LimeAirlinesSystem.Services.Bookings
{
    using LimeAirlinesSystem.Services.Bookings.Models;
    using System.Collections.Generic;

    public interface IBookingService
    {
        IEnumerable<FlightBookingServiceModel> UserBookings(string userId);

        FlightBookingServiceModel BookingDetails(string bookingId);

        string Book(int flightId, int passangers, string userId);

        void CancelBooking(string bookingId);

        void CheckIn(string bookingId);

        bool AddLuggage(
            string bookingId,
            int smallLuggage,
            int mediumLuggage,
            int largeLuggage);
    }
}
