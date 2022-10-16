namespace LimeAirlinesSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Class
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(CategoryAndPassangerMaxLength)]
        public string Name { get; set; }

        public IEnumerable<Passanger> Passangers = new List<Passanger>();
    }
}
