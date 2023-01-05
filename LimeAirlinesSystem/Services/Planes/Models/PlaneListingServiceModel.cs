namespace LimeAirlinesSystem.Services.Planes.Models
{
    public class PlaneListingServiceModel
    {
        public int Id { get; init; }
        public string Brand { get; init; }
        public string Model { get; init; }
        public int NumberOfSeats { get; init; }
        public string ImageUrl { get; init; }
        public int Year { get; init; }
        public string Category { get; init; }
    }
}
