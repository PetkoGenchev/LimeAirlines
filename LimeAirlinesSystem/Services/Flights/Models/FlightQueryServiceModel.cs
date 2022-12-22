namespace LimeAirlinesSystem.Services.Flights.Models
{
    using System.Collections.Generic;

    public class FlightQueryServiceModel
    {
        public int TotalFlights { get; init; }

        public int TotalLocations { get; init; }

        public IEnumerable<CheapestFlightServiceModel> CheapestFlights { get; init; }
        public IEnumerable<FlightServiceModel> Flights { get; init; }
    }
}
