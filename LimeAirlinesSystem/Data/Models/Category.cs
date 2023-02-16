namespace LimeAirlinesSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Category;

    public class Category
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(CategoryMaxLength)]
        public string Name { get; set; }

        public IEnumerable<Plane> Planes { get; init; } = new List<Plane>();
    }
}
