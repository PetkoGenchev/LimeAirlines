﻿namespace LimeAirlinesSystem.Models.Flights
{
    using LimeAirlinesSystem.Services.Flights.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static LimeAirlinesSystem.Infrastructure.Extensions.ExceptionMessages.FlightQueryMessages;

    public class AllFlightsQueryModel : IValidatableObject
    {
        public const int FlightsPerPage = 5;

        public int CurrentPage { get; init; } = 1;

        [Display(Name = "Trip")]
        public string TripType { get; init; }

        [Display(Name = "Departing From")]
        public string StartLocation { get; init; }

        [Display(Name = "Arriving At")]
        public string EndLocation { get; init; }

        [Display(Name = "Departure")]
        [DataType(DataType.Date)]
        public DateTime? FlightDate { get; init; }

        public int Passangers { get; init; } = 1;

        public int MaxTransfers { get; init; } = 1;

        public int MaxPrice { get; init; }

        public FlightSorting Sorting { get; init; }

        public int TotalFlights { get; set; }

        public IEnumerable<string> StartLocations { get; set; }
        public IEnumerable<string> EndLocations { get; set; }

        public IEnumerable<FlightTypeServiceModel> TripTypes { get; set; }

        public IEnumerable<FlightServiceModel> Flights { get; set; }

        public IEnumerable<FlightServiceModel> ReturnFlights { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.StartLocation == this.EndLocation)
            {
                if (this.StartLocation != null)
                {
                    yield return new ValidationResult(LocationError);
                }

            }
        }
    }
}
