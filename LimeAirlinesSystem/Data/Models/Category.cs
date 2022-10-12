namespace LimeAirlinesSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Category
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(PlaneCategoryMaxLength)]
        public string Name { get; set; }

        public IEnumerable<Plane> Planes { get; init; } = new List<Plane>();
    }
}
