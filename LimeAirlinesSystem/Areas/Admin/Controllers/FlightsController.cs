namespace LimeAirlinesSystem.Areas.Admin.Controllers
{
    using LimeAirlinesSystem.Services.Flights;
    using Microsoft.AspNetCore.Mvc;

    public class FlightsController : AdminController
    {
        private readonly IFlightService flights;

        public FlightsController(IFlightService flights) => this.flights = flights;

        public IActionResult All()
        {
            var flights = this.flights
                .All(
                flightDate: System.DateTime.UtcNow,
                publicOnly: false)
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
