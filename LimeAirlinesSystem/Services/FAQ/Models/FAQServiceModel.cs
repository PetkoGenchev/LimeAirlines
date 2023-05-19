namespace LimeAirlinesSystem.Services.FAQs.Models
{
    public class FAQServiceModel
    {
        public int Id { get; init; }
        public string Description { get; init; }
        public string ImageUrl { get; init; }
        public string Title { get; init; }
        public bool IsPublic { get; init; }
    }
}
