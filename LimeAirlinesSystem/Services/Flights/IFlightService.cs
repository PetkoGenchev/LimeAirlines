namespace LimeAirlinesSystem.Services.Flights
{
    using LimeAirlinesSystem.Services.Flights.Models;
    using LimeAirlinesSystem.Services.Planes.Models;
    using System;
    using System.Collections.Generic;

    public interface IFlightService
    {
        FlightQueryServiceModel All(
            string startLocation = null,
            string endLocation = null,
            string flightDateTime = null,
            int passangers = 0,
            string tripType = null,
            int currentPage = 1,
            int flightsPerPage = int.MaxValue,
            bool publicOnly = true
            );

        int Create(
            string startLocation,
            string endLocation,
            string flightDateTime,
            int price,
            string imageUrl,
            int planeId);

        bool Edit(
            int flightId,
            string startLocation,
            string endLocation,
            string flightDateTime,
            int price,
            string imageUrl,
            int planeId,
            bool isPublic);

        IEnumerable<CheapestFlightServiceModel> Cheapest();
        void ChangeVisibility(int flightId);
        IEnumerable<int> AllTripTypes();
        IEnumerable<string> AllDestinations();
        IEnumerable<FlightServiceModel> UserFlights(string userId);
        IEnumerable<PlaneServiceModel> AllPlanes();
        bool PlaneExists(int planeId);

        FlightServiceModel Details(int flightId);

    }
}
