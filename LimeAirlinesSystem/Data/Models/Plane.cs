namespace LimeAirlinesSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Plane
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(PlaneBrandAndModelMaxLength)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(PlaneBrandAndModelMaxLength)]
        public string Model { get; set; }

        [Required]
        [MaxLength(NumberofSeatsMaxLength)]
        public int NumberOfSeats { get; set; }

        [Required]
        public int ImageUrl { get; set; }

        [Required]
        public int Year { get; set; }

        public IEnumerable<Flight> Flights = new List<Flight>();
    }
}