namespace LimeAirlinesSystem.Areas.Admin.Controllers
{
    using LimeAirlinesSystem.Services.Planes;
    using Microsoft.AspNetCore.Mvc;

    public class PlanesController : AdminController
    {
        private readonly IPlaneService planes;

        public PlanesController(IPlaneService planes) => this.planes = planes;

        public IActionResult All()
        {
            var planes = this.planes
                .All()
                .Planes;

            return View(planes);
        }
    }
}
