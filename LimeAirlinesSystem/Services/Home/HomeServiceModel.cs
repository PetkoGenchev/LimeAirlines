namespace LimeAirlinesSystem.Services.Home
{
    using System.Collections.Generic;
    using LimeAirlinesSystem.Models.Flights;
    using LimeAirlinesSystem.Services.Flights.Models;

    public class HomeServiceModel
    {
        public AllFlightsQueryModel QueryModel = new AllFlightsQueryModel();

        public List<CheapestFlightServiceModel> CheapestFlight = new List<CheapestFlightServiceModel>();
    }
}
