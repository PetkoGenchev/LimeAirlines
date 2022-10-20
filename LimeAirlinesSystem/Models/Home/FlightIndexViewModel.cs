using LimeAirlinesSystem.Models.Planes;

namespace LimeAirlinesSystem.Models.Home
{
    public class FlightIndexViewModel
    {
        public int Id { get; init; }
        public string TripType { get; init; }
        public string StartLocation { get; init; }
        public string EndLocation { get; init; }
        public string FlightStartDate { get; init; }
        public string FlightEndDate { get; init; }
        public int Price { get; init; }
        public string ImageUrl { get; init; }


    }
}
