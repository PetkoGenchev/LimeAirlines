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

        [MaxLength(NumberofSeatsMaxValue)]
        public int NumberOfSeats { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int Year { get; set; }


        public IEnumerable<Flight> Flights = new List<Flight>();

        public int CategoryId { get; set; }
        public Category Category { get; init; }

    }
}