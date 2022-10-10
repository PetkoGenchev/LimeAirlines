namespace LimeAirlinesSystem.Controllers
{
    using LimeAirlinesSystem.Data;
    using LimeAirlinesSystem.Models.Planes;
    using Microsoft.AspNetCore.Mvc;

    public class PlanesController : Controller
    {
        private AirlineDbContext data;

        public PlanesController(AirlineDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add() => View();


        [HttpPost]
        public IActionResult Add(AddPlaneFormModel plane)
        {
            return View();
        }
    }
}
