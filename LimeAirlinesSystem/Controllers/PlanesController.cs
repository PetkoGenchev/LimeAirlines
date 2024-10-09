namespace LimeAirlinesSystem.Controllers
{
    using AutoMapper;
    using LimeAirlinesSystem.Models.Planes;
    using LimeAirlinesSystem.Services.Planes;
    using Microsoft.AspNetCore.Mvc;

    public class PlanesController : Controller

    {
        private readonly IPlaneService planes;
        private readonly IMapper mapper;

        public PlanesController(
            IPlaneService planes,
            IMapper mapper)
        {
            this.planes = planes;
            this.mapper = mapper;
        }


        public IActionResult All([FromQuery] AllPlanesQueryModel query)
        {
            var queryResult = this.planes.All(
                query.CurrentPage,
                AllPlanesQueryModel.PlanesPerPage);

            query.TotalPlanes = queryResult.TotalPlanes;
            query.Planes = queryResult.Planes;

            return View(query);
        }
    }
}
