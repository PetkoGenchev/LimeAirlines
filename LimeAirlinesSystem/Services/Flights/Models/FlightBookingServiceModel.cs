using System;

namespace LimeAirlinesSystem.Services.Flights.Models
{
    public class FlightBookingServiceModel
    {
        public string Id { get; init; }
        public string UserId { get; init; }
        public int CountOfSeats { get; init; }
        public int FlightId { get; init; }
        public string StartLocation { get; init; }
        public string EndLocation { get; init; }
        public DateTime FlightDate { get; init; }
        public int Price { get; init; }
        public bool IsCancelled { get; init; }
    }

}
