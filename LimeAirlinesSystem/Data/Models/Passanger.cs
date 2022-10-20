namespace LimeAirlinesSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;
    public class Passanger
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(CategoryAndPassangerMaxLength)]
        public string Name { get; set; }

        
        [MaxLength(NumberofSeatsMaxValue)]
        public int Count { get; set; }

        public int FlightId { get; set; }
        public Flight Flight { get; init; }


    }
}
