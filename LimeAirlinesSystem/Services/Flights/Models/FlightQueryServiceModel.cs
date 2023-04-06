namespace LimeAirlinesSystem.Services.Flights.Models
{
    using System.Collections.Generic;

    public class FlightQueryServiceModel
    {
        public int CurrentPage { get; init; }

        public int FlightsPerPage { get; init; }

        public int TotalFlights { get; init; }

        public int BookingSeats { get; init; }

        public IEnumerable<FlightServiceModel> Flights { get; set; }

        public IEnumerable<FlightServiceModel> ReturnFlights { get; set; }
    }
}
