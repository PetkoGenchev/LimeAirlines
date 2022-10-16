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
        public bool typeOfTrip { get; init; }

        [Required]
        [StringLength(FlightLocationMaxLength,MinimumLength = FlightLocationMinLength)]
        [Display(Name = "Departing from")]
        public string StartLocation { get; set; }

        [Required]
        [StringLength(FlightLocationMaxLength, MinimumLength = FlightLocationMinLength)]
        [Display(Name = "Arriving at")]
        public string EndLocation { get; set; }

        [Required]
        public DateTime FlightStartDate { get; set; }

        [Required]
        public DateTime FlightEndDate { get; set; }

        public int PlaneId { get; set; }

        public IEnumerable<Passanger> Passangers = new List<Passanger>();
    }
