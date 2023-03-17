namespace LimeAirlinesSystem.Models.Flights
{
    using LimeAirlinesSystem.Services.Flights.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AllFlightsQueryModel
    {
        public const int FlightsPerPage = 5;
        //public const int MinimumAmountofTransfers = 0;
        //public const int MaximumAmountofTransfers = 2;
        //public const int MinimumPrice = 0;
        //public const int MaximumPrice = 5000;

        [Display(Name = "Trip")]
        public string TripType { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalFlights { get; set; }

        [Display(Name = "Departing From")]
        public string StartLocation { get; init; }

        [Display(Name = "Arriving At")]
        public string EndLocation { get; init; }

        [Display(Name = "Departure")]
        [DataType(DataType.Date)]
        public DateTime FlightDate { get; init; } = DateTime.UtcNow;

        public int MaxTransfers { get; init; }

        public int MaxPrice { get; init; }
        public FlightSorting Sorting { get; init; }

        public int Passangers { get; init; }

        public IEnumerable<string> StartLocations { get; set; }
        public IEnumerable<string> EndLocations { get; set; }

        public IEnumerable<FlightTypeServiceModel> TripTypes { get; set; }

        public IEnumerable<FlightServiceModel> Flights { get; set; }
    }
}
