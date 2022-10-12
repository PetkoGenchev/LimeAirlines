using System.ComponentModel.DataAnnotations;

namespace LimeAirlinesSystem.Models.Planes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class AddPlaneFormModel
    {
        [Required]
        [StringLength(PlaneBrandAndModelMaxLength, MinimumLength = PlaneBrandAndModelMinLength)]
        public string Brand { get; init; }

        [Required]
        [StringLength(
            PlaneBrandAndModelMaxLength, 
            MinimumLength = PlaneBrandAndModelMinLength,
            ErrorMessage = "The field Model must be a text with a minimum length of {1}")]
        public string Model { get; init; }

        [Range(NumberofSeatsMinValue, NumberofSeatsMaxValue)]
        [Display(Name = "Number of Seats")]
        public int NumberOfSeats { get; init; }

        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }

        [Range(PlaneMinValue,PlaneMaxValue)]
        public int Year { get; init; }

        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        public IEnumerable<PlaneCategoryViewModel> Categories { get; set; }
    }
}