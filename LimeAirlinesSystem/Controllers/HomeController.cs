namespace LimeAirlinesSystem.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using LimeAirlinesSystem.Data;
    using LimeAirlinesSystem.Models;
    using LimeAirlinesSystem.Models.Planes;
    using LimeAirlinesSystem.Services.Flights.Models;
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

            //return this.RedirectToAction("All","Flights",new {model = FilteredFlightsQueryModel{})
        }


        private IEnumerable<FlightTypeServiceModel> GetFlightTypes()
            => this.data
                .TripTypes
                .Select(f => new FlightTypeServiceModel
                {
                    Id = f.Id,
                    Name = f.Name
                })
                .ToList();


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}