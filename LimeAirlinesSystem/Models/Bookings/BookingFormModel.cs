namespace LimeAirlinesSystem.Models.Bookings
{
    using System.ComponentModel.DataAnnotations;
    using System;

    using static Data.DataConstants.BaggageConstants;
    using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

    public class BookingFormModel
    {
        [Required]
        [Range(BaggageMinCount, BaggageMaxCount)]
        [Display(Name = "Small Baggage")]
        public int SmallBaggage { get; init; }

        [Required]
        [Range(BaggageMinCount, BaggageMaxCount)]
        [Display(Name = "Medium Baggage")]
        public int MediumBaggage { get; init; }

        [Required]
        [Range(BaggageMinCount, BaggageMaxCount)]
        [Display(Name = "Large Baggage")]
        public int LargeBaggage { get; init; }

    }
}
