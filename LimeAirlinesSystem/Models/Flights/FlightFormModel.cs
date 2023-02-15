﻿namespace LimeAirlinesSystem.Models.Flights
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System;
    using LimeAirlinesSystem.Services.Flights.Models;

    using static Data.DataConstants;
    using LimeAirlinesSystem.Services.Planes.Models;

    public class FlightFormModel : IFlightModel
    {
        [Required]
        [StringLength(FlightLocationMaxLength, MinimumLength = FlightLocationMinLength)]
        [Display(Name = "Departing from")]
        public string StartLocation { get; init; }

        [Required]
        [StringLength(FlightLocationMaxLength, MinimumLength = FlightLocationMinLength)]
        [Display(Name = "Arriving at")]
        public string EndLocation { get; init; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Departure")]
        public DateTime FlightStartDate { get; init; } = DateTime.UtcNow;


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Arrival")]
        public DateTime FlightEndDate { get; init; } = DateTime.UtcNow;


        [MaxLength(FlightMinValue)]
        [Display(Name = "Fare")]
        public int Price { get; set; }

        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }


        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Flight Duration")]
        public TimeSpan FlightDuration { get; init; }

        [Required]
        [Display(Name = "Transfers")]
        public int Transfer { get; init; }


        [Display(Name = "Aircraft Type")]
        public int PlaneId { get; init; }

        public IEnumerable<PlaneServiceModel> Planes { get; set; }
    }
}