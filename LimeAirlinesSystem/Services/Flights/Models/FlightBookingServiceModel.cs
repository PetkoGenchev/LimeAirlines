using System;

namespace LimeAirlinesSystem.Services.Flights.Models
{
    public class FlightBookingServiceModel : FlightServiceModel
    {
        public int BookingId { get; init; }
        public int CountOfSeats { get; set; }
        public bool IsCancelled { get; set; }
    }

}
