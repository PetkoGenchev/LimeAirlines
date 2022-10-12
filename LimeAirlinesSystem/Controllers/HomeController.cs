namespace LimeAirlinesSystem.Controllers
{
    using System.Diagnostics;
    using LimeAirlinesSystem.Data;
    using LimeAirlinesSystem.Models;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly AirlineDbContext data;

        public HomeController(AirlineDbContext data)
        {
            this.data = data;
        }

        public IActionResult Index() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() 
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
