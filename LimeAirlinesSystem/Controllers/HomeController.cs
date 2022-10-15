namespace LimeAirlinesSystem.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using LimeAirlinesSystem.Data;
    using LimeAirlinesSystem.Models;
    using LimeAirlinesSystem.Models.Planes;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly AirlineDbContext data;

        public HomeController(AirlineDbContext data)
        {
            this.data = data;
        }

        public IActionResult Index()
        {
            var cars = this.data
                .Planes
                .OrderByDescending(p => p.Id)
                .Select(p => new PlaneListingViewModel
                {
                    Id = p.Id,
                    Brand = p.Brand,
                    Model = p.Model,
                    ImageUrl = p.ImageUrl,
                    Year = p.Year,
                    Category = p.Category.Name
                })
                .Take(3)
                .ToList();

            return View(cars);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() 
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
