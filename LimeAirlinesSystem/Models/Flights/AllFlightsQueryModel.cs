namespace LimeAirlinesSystem.Models.Flights
{
    using LimeAirlinesSystem.Data.Models;
    using LimeAirlinesSystem.Services.Flights.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

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
        //public string FlightDate { get; init; } = DateTime.UtcNow.ToString();
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
