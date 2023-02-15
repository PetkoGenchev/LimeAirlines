namespace LimeAirlinesSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
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
        public string FlightStartDate { get; set; }

        [Required]
        public string FlightEndDate { get; set; }

        public TimeSpan FlightDuration { get; set; }

        public int Transfer { get; set; }


        [MaxLength(FlightMinValue)]
        public int Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public bool IsPublic { get; set; }

        public int PlaneId { get; set; }
        public Plane Plane { get; init; }

        public IEnumerable<Passanger> Passangers = new List<Passanger>();


    }
}