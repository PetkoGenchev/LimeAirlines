namespace LimeAirlinesSystem.Areas.Admin.Controllers
{
    public class PlanesController : AdminController
    {
        private readonly IPlaneService planes;

        public PlanesController(IPlaneService planes) => this.planes = planes;

        public IActionResult All()
        {
            var planes = this.planes.Planes;

            return View(planes);
        }
    }
}
