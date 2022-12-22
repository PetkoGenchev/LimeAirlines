namespace LimeAirlinesSystem.Models.Flights
{
    using System.Collections.Generic;
    public class FilteredFlightsQueryModel
    {
        public IEnumerable<int> MaxPrice { get; init; }

        public IEnumerable<string> DepartureTime { get; init; }

        public IEnumerable<int> MaxDuration { get; init; }

        public FlightSorting Sorting { get; init; }

        public int TotalPrice { get; init; }


        // I need to receive flight options that were filtered in Index
    }
}
