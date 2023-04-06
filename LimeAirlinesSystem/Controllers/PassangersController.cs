using LimeAirlinesSystem.Areas.Admin;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LimeAirlinesSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;


    public class PassangersController : Controller
    {

    }
}




// NEED TO ADD FUNCTIONALITY FOR PASSANGERS TAKING SEATS
// (Reserve button on a flight, add flight to passanger flight list,
//  

//     AND CHANGE VISIBLITY FOR FULL FLIGHTS AFTER RESERVATION (have avaiable seats change with reservations)







//    location of my flights data :

//in flights controller - mine
//in flight service  - UserFlights

//Views - Passangers - Mine and _FlightsPartial  - both views not fixed with proper info in them ... to show mine and have buttons
// (the buttons are - Cancel Flight, Check In, View Information for flight)




// ADMIN CAN HIDE UPCOMING FLIGHT AND IF PEOPLE HAVE RESERVATIONS ON IT, IT CANCELS ALL RESERVATIONS