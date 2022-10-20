namespace LimeAirlinesSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class TripType
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(FlightMinValue)]
        public string Name { get; set; }
    }
}
