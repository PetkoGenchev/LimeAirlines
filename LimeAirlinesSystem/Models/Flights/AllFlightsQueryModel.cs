﻿namespace LimeAirlinesSystem.Models.Flights
{
    using LimeAirlinesSystem.Services.Flights.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AllFlightsQueryModel
    {
        public const int FlightsPerPage = 3;

        [Display(Name = "Trip")]
        public string TripType { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalFlights { get; set; }

        [Display(Name = "Departing From")]
        public string StartLocation { get; init; }

        [Display(Name = "Arriving At")]
        public string EndLocation { get; init; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Departure")]
        public string FlightDateTime { get; init; } = DateTime.UtcNow.ToString();

        public int Passangers { get; init; }

        public IEnumerable<int> TripTypes { get; set; }

        public IEnumerable<string> Locations { get; set; }

        public IEnumerable<FlightServiceModel> Flights { get; set; }
    }
}