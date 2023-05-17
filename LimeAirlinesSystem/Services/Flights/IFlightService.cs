namespace LimeAirlinesSystem.Services.Flights
{
    using LimeAirlinesSystem.Models;
    using LimeAirlinesSystem.Services.Bookings.Models;
    using LimeAirlinesSystem.Services.Flights.Models;
    using LimeAirlinesSystem.Services.Planes.Models;
    using System;
    using System.Collections.Generic;

    public interface IFlightService
    {
        FlightQueryServiceModel All(
            DateTime? flightDate,
            string startLocation = null,
            string endLocation = null,
            int passangers = 1,
            string tripType = null,
            int maxTransfers = int.MaxValue,
            int maxPrice = int.MaxValue,
            FlightSorting sorting = FlightSorting.Duration,
            int currentPage = 1,
            int flightsPerPage = int.MaxValue,
            bool publicOnly = true
            );

        FlightQueryServiceModel All(
            int currentPage = 1,
            int flightsPerPage = int.MaxValue
            );

        void Create(
            string startLocation,
            string endLocation,
            DateTime flightDate,
            int price,
            string imageUrl,
            TimeSpan flightDuration,
            int transfer,
            int planeId);

        bool Edit(
            int flightId,
            string startLocation,
            string endLocation,
            DateTime flightDate,
            int price,
            string imageUrl,
            TimeSpan flightDuration,
            int transfer,
            int planeId,
            bool isPublic);

        IEnumerable<CheapestFlightServiceModel> Cheapest();
        void ChangeVisibility(int flightId);
        IEnumerable<FlightTypeServiceModel> AllTripTypes();
        IEnumerable<string> AllStartingLocations();
        IEnumerable<string> AllFinalLocations();
        IEnumerable<PlaneServiceModel> AllPlanes();
        bool PlaneExists(int planeId);
        FlightServiceModel FlightDetails(int flightId);

        void CancelFlight(int flightId);

    }
}
