namespace LimeAirlinesSystem.Models.Planes
{
    using System.Collections.Generic;
    using LimeAirlinesSystem.Services.Planes.Models;

    public class AllPlanesQueryModel
    {
        public const int PlanesPerPage = 6;

        public int CurrentPage { get; init; } = 1;

        public int TotalPlanes { get; set; }

        public IEnumerable<PlaneServiceModel> Planes { get; set; }
    }
}
