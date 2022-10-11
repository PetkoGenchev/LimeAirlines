namespace LimeAirlinesSystem.Models.Planes
{
    using System.ComponentModel.DataAnnotations;

    public class AddPlaneFormModel
    {
        public string Brand { get; init; }

        public string Model { get; init; }

        [Display(Name = "Number of Seats")]
        public int NumberOfSeats { get; init; }

        [Display(Name = "Image URL")]
        public int ImageUrl { get; init; }

        public int Year { get; init; }
    }
}




