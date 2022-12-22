namespace LimeAirlinesSystem.Models.Flights
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class FlightsQueryModel
    {
        [Display(Name = "Departing From")]
        public string StartLocation { get; init; }

        [Display(Name = "Arriving At")]
        public string EndLocation { get; init; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Departure")]
        public DateTime FlightStartDate { get; init; } = DateTime.UtcNow;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Return")]
        public DateTime FlightEndDate { get; init; } = DateTime.UtcNow;

        public int Passangers { get; init; }


        [Display(Name = "Trip")]
        public int TripTypeId { get; init; }

        public IEnumerable<FlightTypeViewModel> TripTypes { get; set; }
        public IEnumerable<string> Locations { get; set; }
        public List<FlightIndexViewModel> Flights { get; init; }
    }
}
