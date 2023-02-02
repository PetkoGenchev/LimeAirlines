namespace LimeAirlinesSystem.Models.Api.Planes
{
    public class AllPlanesApiRequestModel
    {
        public int CurrentPage { get; init; } = 1;

        public int PlanesPerPage { get; init; } = 10;
    }
}