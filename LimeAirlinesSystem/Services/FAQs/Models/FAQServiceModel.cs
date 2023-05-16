namespace LimeAirlinesSystem.Services.Information.Models
{
    public class FAQServiceModel
    {
        public int Id { get; init; }
        public string Model { get; init; }
        public string ImageUrl { get; init; }
        public string Title { get; init; }
        public bool IsPublic { get; init; }
    }
}
