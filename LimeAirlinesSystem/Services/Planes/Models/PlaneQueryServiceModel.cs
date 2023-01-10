namespace LimeAirlinesSystem.Services.Planes.Models
{
    using System.Collections.Generic;

    public class PlaneQueryServiceModel
    {

        public int CurrentPage {get; init;}

        public int PlanesPerPage { get; init; }

        public int TotalPlanes { get; init; }

        public IEnumerable<PlaneServiceModel> Planes { get; init; }
    }
}
