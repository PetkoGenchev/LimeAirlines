namespace LimeAirlinesSystem.Models.Flights
{
    using LimeAirlinesSystem.Services.Flights.Models;
    using System.Collections.Generic;
    public class FilteredFlightsQueryModel
    {
        public const int FlightsPerPage = 10;

        public int CurrentPage { get; init; } = 1;

        public int TotalFlights { get; set; }

        public int MaxPrice { get; init; }

        public string DepartureTime { get;init; }

        public IEnumerable<int> MaxPrices { get; init; }

        public IEnumerable<string> DepartureTimes { get; init; }

        public FlightSorting Sorting { get; init; }

        public List<FlightServiceModel> Flights { get; init; }
    }
}
