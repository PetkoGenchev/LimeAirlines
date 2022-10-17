using LimeAirlinesSystem.Models.Planes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LimeAirlinesSystem.Models.Flights
{
    using LimeAirlinesSystem.Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System;

    using static Data.DataConstants;

    public class AddFlightFormModel
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
        public DateTime FlightStartDate { get; init; }

        [Required]
        public DateTime FlightEndDate { get; init; }

        public int PlaneId { get; init; }

        public IEnumerable<PlaneListingViewModel> Planes { get; set; }
    }
}