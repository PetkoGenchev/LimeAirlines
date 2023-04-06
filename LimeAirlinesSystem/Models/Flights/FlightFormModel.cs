namespace LimeAirlinesSystem.Models.Flights
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System;
    using LimeAirlinesSystem.Services.Flights.Models;
    using LimeAirlinesSystem.Services.Planes.Models;

    using static Data.DataConstants.FlightConstants;


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
        [Display(Name = "Flight Date")]
        public DateTime FlightDate { get; init; } = DateTime.UtcNow;

        [Required]
        [Range(FlightPriceMinValue, FlightPriceMaxValue)]
        [Display(Name = "Price")]
        public int Price { get; init; }

        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Flight Duration")]
        public TimeSpan FlightDuration { get; init; }

        [Required]
        [Range(TransferCountMinValue, TransferCountMaxValue)]
        [Display(Name = "Number of Transfers")]
        public int Transfer { get; init; }


        [Display(Name = "Aircraft Type")]
        public int PlaneId { get; init; }

        public IEnumerable<PlaneServiceModel> Planes { get; set; }
    }
}