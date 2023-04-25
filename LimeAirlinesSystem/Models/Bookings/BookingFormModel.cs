namespace LimeAirlinesSystem.Models.Bookings
{
    using Microsoft.Build.Framework;
    using System.ComponentModel.DataAnnotations;
    using System;

    using static Data.DataConstants.LuggageConstants;
    using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

    public class BookingFormModel
    {
        [Required]
        [Range(LuggageMinCount, LuggageMaxCount)]
        [Display(Name = "Small Luggage")]
        public int SmallLuggage { get; init; }

        [Required]
        [Range(LuggageMinCount, LuggageMaxCount)]
        [Display(Name = "Medium Luggage")]
        public int MediumLuggage { get; init; }

        [Required]
        [Range(LuggageMinCount, LuggageMaxCount)]
        [Display(Name = "Large Luggage")]
        public int LargeLuggage { get; init; }

    }
}
