namespace LimeAirlinesSystem.Services.Flights
{
    using LimeAirlinesSystem.Models;
    using LimeAirlinesSystem.Services.Flights.Models;
    using LimeAirlinesSystem.Services.Planes.Models;
    using System;
    using System.Collections.Generic;

    public interface IFlightService
    {
        FlightQueryServiceModel All(
            string startLocation = null,
            string endLocation = null,
            string flightDate = null,
            int passangers = 0,
            string tripType = null,
            int maxPrice = int.MaxValue,
            FlightSorting sorting = FlightSorting.Duration,
            int currentPage = 1,
            int flightsPerPage = int.MaxValue,
            bool publicOnly = true
            );

        int Create(
            string startLocation,
            string endLocation,
            string flightDate,
            int price,
            string imageUrl,
            int planeId);

        bool Edit(
            int flightId,
            string startLocation,
            string endLocation,
            string flightDate,
            int price,
            string imageUrl,
            int planeId,
            bool isPublic);

        IEnumerable<CheapestFlightServiceModel> Cheapest();
        void ChangeVisibility(int flightId);
        IEnumerable<FlightTypeServiceModel> AllTripTypes();
        IEnumerable<string> AllStartingLocations();
        IEnumerable<string> AllFinalLocations();
        IEnumerable<FlightServiceModel> UserFlights(string userId);
        IEnumerable<PlaneServiceModel> AllPlanes();
        bool PlaneExists(int planeId);

        FlightServiceModel Details(int flightId);

    }
}
