namespace LimeAirlinesSystem.Services.Home
{
    using System.Collections.Generic;
    using LimeAirlinesSystem.Models.Flights;
    using LimeAirlinesSystem.Services.Flights.Models;

    public class HomeServiceModel
    {
        public AllFlightsQueryModel FlightsQuery { get; set; } = new AllFlightsQueryModel();

        public List<CheapestFlightServiceModel> CheapestFlight { get; set; }
    }
}
