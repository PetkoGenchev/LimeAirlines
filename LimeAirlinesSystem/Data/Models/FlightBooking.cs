namespace LimeAirlinesSystem.Data.Models
{
    using System;
    public class FlightBooking
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public int CountOfSeats { get; set; }
        public int FlightId { get; set; }
        public Flight Flight { get; init; }
        public bool IsCancelled { get; set; }
        public bool IsCheckedIn { get; set; }
        public int SmallBaggage { get; set; }
        public int MediumBaggage { get; set; }
        public int LargeBaggage { get; set; }
        public int TotalPrice { get; set; }
        public string ImageUrl { get; set; }
    }
}
