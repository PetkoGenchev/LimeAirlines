namespace LimeAirlinesSystem.Controllers
{
    using LimeAirlinesSystem.Services.Home;
    using Microsoft.AspNetCore.Mvc;
    using LimeAirlinesSystem.Areas.Admin;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;


    public class FAQController : Controller
    {
        public IActionResult General()
        {
            return View();
        }
    }
}


//Views - Passangers - Mine and _FlightsPartial  - both views not fixed with proper info in them ... to show mine and have buttons
// (the buttons are - Cancel Flight, Check In, View Information for flight)


// FIX BOOKING ROUND TRIP STAY ON PAGE
// FIX WHAT IS SEEN ON MY FLIGHTS PAGE



// maybe make FAQ page with number of positive raitings for the article (1 person cannot click multiple times)
