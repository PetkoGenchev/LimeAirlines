namespace LimeAirlinesSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.FAQConstants;

    public class FAQ
    {
        public int Id { get; init; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(InformationTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsPublic { get; set; }
    }
}
