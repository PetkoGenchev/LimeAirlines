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
        public DateTime FlightStartDate { get; set; }

        [Required]
        public DateTime FlightEndDate { get; set; }

        public int PlaneId { get; set; }
        public Plane Plane { get; init; }

        public IEnumerable<Passanger> Passangers = new List<Passanger>();
    }
}


// NEED TO ADD TYPE OF TRIP WHEN YOU SEARCH ON HOME AND SHOULD SHOW 2 TRIPS
//public bool typeOfTrip { get; init; }
//One - way or Round Trip