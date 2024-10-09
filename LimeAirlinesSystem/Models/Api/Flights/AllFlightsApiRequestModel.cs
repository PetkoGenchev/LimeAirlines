namespace LimeAirlinesSystem.Models.Api.Flights
{
    using System;
    public class AllFlightsApiRequestModel
    {
        public string TripType { get; init; }
        public string StartLocation { get; init; }
        public string EndLocation { get; init; }
        public DateTime FlightDate { get; set; } = DateTime.UtcNow;
        public TimeSpan FlightDuration { get; init; }
        public int MaxTransfers { get; init; }
        public int MaxPrice { get; init; }
        public FlightSorting Sorting { get; init; }
        public int Passangers { get; init; }
        public int CurrentPage { get; init; } = 1;

        public int FlightsPerPage = 10;
    }
}