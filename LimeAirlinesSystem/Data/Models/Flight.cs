namespace LimeAirlinesSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Flight
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(FlightLocationMaxLength)]
        public string StartLocation { get; set; }

        [Required]
        [MaxLength(FlightLocationMaxLength)]
        public string EndLocation { get; set; }

        [Required]
        public DateTime FlightStartDate { get; set; }

        [Required]
        public DateTime FlightEndDate { get; set; }

        public int PlaneId { get; set; }
        public Plane Plane { get; init; }
    }
}
