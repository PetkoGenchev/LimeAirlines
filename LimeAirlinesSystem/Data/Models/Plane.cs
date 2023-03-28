namespace LimeAirlinesSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Plane;

    public class Plane
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(PlaneBrandAndModelMaxLength)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(PlaneBrandAndModelMaxLength)]
        public string Model { get; set; }

        [MaxLength(NumberofSeatsMaxValue)]
        public int NumberOfSeats { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public int Year { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; init; }
        public bool IsPublic { get; set; }
        public IEnumerable<Flight> Flights { get; init; } = new List<Flight>();

    }
}