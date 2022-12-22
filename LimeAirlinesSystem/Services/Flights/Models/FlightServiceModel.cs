namespace LimeAirlinesSystem.Services.Flights.Models
{
    public class FlightIndexViewModel : IFlightModel
    {
        public int Id { get; init; }
        public string StartLocation { get; init; }
        public string EndLocation { get; init; }
        public string FlightStartDate { get; init; }
        public string FlightEndDate { get; init; }
        public int Price { get; init; }
        public string ImageUrl { get; init; }


    }
}
