namespace LimeAirlinesSystem.Models.Flights
{
    using LimeAirlinesSystem.Services.Flights.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class AllFlightsQueryModel
    {
        public const int FlightsPerPage = 5;

        [Display(Name = "Trip")]
        public string TripType { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalFlights { get; set; }

        [Display(Name = "Departing From")]
        public string StartLocation { get; init; }

        [Display(Name = "Arriving At")]
        public string EndLocation { get; init; }

        [Display(Name = "Departure")]
        public string FlightStartDate { get; init; } = DateTime.UtcNow.ToString();

        [Display(Name = "Arrival")]
        public string FlightEndDate { get; init; } = DateTime.UtcNow.ToString();

        public int MaxTransfers { get; init; }

        public int MaxPrice { get; init; }
        public FlightSorting Sorting { get; init; }

        public int Passangers { get; init; }

        public IEnumerable<int> TripTypes { get; set; }

        public IEnumerable<string> Locations { get; set; }

        public IEnumerable<FlightServiceModel> Flights { get; set; }

        //public IEnumerable<CheapestFlightServiceModel> CheapestFlight { get; set; } = new List<CheapestFlightServiceModel>();
    }
}
