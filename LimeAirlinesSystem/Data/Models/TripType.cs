namespace LimeAirlinesSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TripType
    {
        public int Id { get; init; }


        [Required]
        public string Name { get; set; }
    }
}
