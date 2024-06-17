using System;

namespace LimeAirlinesSystem.Services.Bookings.Models
{
    public class FlightBookingServiceModel
    {
        public string Id { get; init; }
        public string UserId { get; init; }
        public int CountOfSeats { get; init; }
        public int FlightId { get; init; }
        public string StartLocation { get; init; }
        public string EndLocation { get; init; }
        public DateTime? FlightDate { get; init; }
        public int Price { get; init; }
        public bool IsCancelled { get; init; }
        public bool IsCheckedIn { get; init; }
        public int SmallBaggage { get; init; }
        public int MediumBaggage { get; init; }
        public int LargeBaggage { get; init; }
        public int TotalPrice { get; init; }
        public string ImageUrl { get; init; }
    }

}
