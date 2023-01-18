using LimeAirlinesSystem.Services.Flights;
using LimeAirlinesSystem.Services.Planes;
using Microsoft.AspNetCore.Mvc;

namespace LimeAirlinesSystem.Areas.Admin.Controllers
{
    public class FlightsController : AdminController
    {
        private readonly IFlightService flights;

        public FlightsController(IFlightService flights) => this.flights = flights;

        public IActionResult All()
        {
            var flights = this.flights
                .All(publicOnly: false)
                .Flights;

            return View(flights);
        }

        public IActionResult ChangeVisibility(int id)
        {
            this.flights.ChangeVisibility(id);

            return RedirectToAction(nameof(All));
        }
    }
}
