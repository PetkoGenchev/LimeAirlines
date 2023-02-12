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
            string flightStartDateTime = null,
            string flightEndDateTime = null,
            int passangers = 0,
            string tripType = null,
            int currentPage = 1,
            int flightsPerPage = int.MaxValue,
            bool publicOnly = true
            );


        //public FlightQueryServiceModel FilteredView(
        //    int flightsPerPage = int.MaxValue,
        //    int currentPage = 1,
        //    int maxPrice = int.MaxValue,
        //    string departureTime = null,
        //    FlightSorting sorting = FlightSorting.DepartureTime
        //    );

        int Create(
            string startLocation,
            string endLocation,
            string flightStartDateTime,
            string flightEndDateTime,
            int price,
            string imageUrl,
            int planeId);

        bool Edit(
            int flightId,
            string startLocation,
            string endLocation,
            string flightStartDateTime,
            string flightEndDateTime,
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
