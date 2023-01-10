namespace LimeAirlinesSystem.Services.Flights
{
    using AutoMapper;
    using LimeAirlinesSystem.Data;
    using LimeAirlinesSystem.Services.Flights.Models;
    using System.Collections.Generic;
    public class FlightService : IFlightService
    {
        private readonly AirlineDbContext data;
        private readonly IConfigurationProvider mapper;

        public FlightService(AirlineDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper.ConfigurationProvider;
        }


        public FlightQueryServiceModel All(
            string startLocation = null, 
            string endLocation = null, 
            string flightDateTime = null, 
            int passangers = 0, 
            string tripType = null, 
            int currentPage = 1, 
            int flightsPerPage = int.MaxValue)
        {
            
        }

        public IEnumerable<string> AllDestinations()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<FlightTypeServiceModel> AllTripTypes()
        {
            throw new System.NotImplementedException();
        }

        public void ChangeVisibility(int flightId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CheapestFlightServiceModel> Cheapest()
        {
            throw new System.NotImplementedException();
        }

        public int Create(string startLocation, string endLocation, string flightDateTime, int price, string imageUrl, int planeId)
        {
            throw new System.NotImplementedException();
        }

        public int Edit(int flightId, string startLocation, string endLocation, string flightDateTime, int price, string imageUrl, int planeId, bool isPublic)
        {
            throw new System.NotImplementedException();
        }
    }
}
