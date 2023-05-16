namespace LimeAirlinesSystem.Models.FAQs
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Linq;
    using LimeAirlinesSystem.Data;

    using static Data.DataConstants.FAQConstants;


    public class FAQFormModel
    {
        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }


        [Required]
        [StringLength(InformationTitleMaxLength, MinimumLength = InformationTitleMinLength)]
        public string Title { get; init; }


        [Required]
        [StringLength(InformationDescriptionMaxLength, MinimumLength = InformationDescriptionMinLength)]
        public string Description { get; init; }


    }
}
