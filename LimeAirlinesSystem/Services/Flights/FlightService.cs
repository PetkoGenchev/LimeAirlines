namespace LimeAirlinesSystem.Services.Flights
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using LimeAirlinesSystem.Data;
    using LimeAirlinesSystem.Data.Models;
    using LimeAirlinesSystem.Models;
    using LimeAirlinesSystem.Services.Flights.Models;
    using LimeAirlinesSystem.Services.Planes.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
            DateTime flightDate,
            string startLocation = null,
            string endLocation = null,
            int passangers = 0,
            string tripType = null,
            int maxPrice = int.MaxValue,
            FlightSorting sorting = FlightSorting.Duration,
            int currentPage = 1,
            int flightsPerPage = int.MaxValue,
            bool publicOnly = true)
        {

            if (tripType == "Round Trip")
            {
                // ADD HERE FUNCTIONALITITES FOR ONE-WAY AND ROUND TRIPS
            }

            var flightQuery = this.data.Flights
                .Where(f => !publicOnly || f.IsPublic);

            if (!string.IsNullOrEmpty(startLocation))
            {
                flightQuery = flightQuery.Where(f => f.StartLocation == startLocation);
            }

            if (!string.IsNullOrEmpty(endLocation))
            {
                flightQuery = flightQuery.Where(f => f.StartLocation == endLocation);
            }

            flightQuery = flightQuery.Where(f => f.ReservedSeats + passangers <= f.Plane.NumberOfSeats);


            flightQuery = flightQuery.Where(f => f.FlightDate == flightDate);


            if (maxPrice != int.MaxValue)
            {
                flightQuery = flightQuery.Where(f => f.Price <= maxPrice);
            }


            flightQuery = sorting switch
            {
                FlightSorting.Duration => flightQuery.OrderBy(f => f.FlightDuration),
                FlightSorting.LowestPrice => flightQuery.OrderBy(f => f.Price),
                FlightSorting.Transfers or _ => flightQuery.OrderBy(f => f.Transfer)
            };



            var totalFlights = flightQuery.Count();

            var flights = GetFlights(flightQuery
                .Skip((currentPage - 1) * flightsPerPage)
                .Take(flightsPerPage));

            return new FlightQueryServiceModel
            {
                CurrentPage = currentPage,
                TotalFlights = totalFlights,
                FlightsPerPage = flightsPerPage,
                Flights = flights
            };
        }


        public int Create(
            string startLocation,
            string endLocation,
            DateTime flightDate,
            int price,
            string imageUrl,
            int planeId)
        {
            var flightData = new Flight
            {
                StartLocation = startLocation,
                EndLocation = endLocation,
                FlightDate = flightDate,
                Price = price,
                ImageUrl = imageUrl,
                PlaneId = planeId,
                IsPublic = true,
                ReservedSeats = 0
            };

            this.data.Flights.Add(flightData);
            this.data.SaveChanges();

            return flightData.Id;
        }

        public bool Edit(
            int flightId,
            string startLocation,
            string endLocation,
            DateTime flightDate,
            int price,
            string imageUrl,
            int planeId,
            bool isPublic)
        {
            var flightData = this.data.Flights.Find(flightId);

            if (flightData == null)
            {
                return false;
            }

            flightData.StartLocation = startLocation;
            flightData.EndLocation = endLocation;
            flightData.Price = price;
            flightData.IsPublic = isPublic;
            flightData.FlightDate = flightDate;
            flightData.PlaneId = planeId;
            flightData.ImageUrl = imageUrl;

            this.data.SaveChanges();

            return true;
        }

        public IEnumerable<string> AllStartingLocations()
            => this.data
            .Flights
            .Select(f => f.StartLocation)
            .Distinct()
            .OrderBy(br => br)
            .ToList();

        public IEnumerable<string> AllFinalLocations()
            => this.data
            .Flights
            .Select(f => f.EndLocation)
            .Distinct()
            .OrderBy(br => br)
            .ToList();

        public IEnumerable<FlightTypeServiceModel> AllTripTypes()
            => this.data
            .TripTypes
            .ProjectTo<FlightTypeServiceModel>(this.mapper)
            .ToList();

        public void ChangeVisibility(int flightId)
        {
            var flight = this.data.Flights.Find(flightId);

            flight.IsPublic = !flight.IsPublic;
        }

        public IEnumerable<CheapestFlightServiceModel> Cheapest()
            => this.data
            .Flights
            .Where(f => f.IsPublic)
            .OrderBy(p => p.Price)
            .ProjectTo<CheapestFlightServiceModel>(this.mapper)
            .Take(4)
            .ToList();

        private IEnumerable<FlightServiceModel> GetFlights(IQueryable<Flight> flightQuery)
            => flightQuery
                .ProjectTo<FlightServiceModel>(this.mapper)
                .ToList();

        public IEnumerable<FlightServiceModel> UserFlights(string userId)
            => GetFlights(this.data
                .Flights
                .Where(f => f.Passangers.Any(c => c.Id == userId)));

        public IEnumerable<PlaneServiceModel> AllPlanes()
            => this.data
            .Planes
            .ProjectTo<PlaneServiceModel>(this.mapper)
            .ToList();

        public bool PlaneExists(int planeId)
            => this.data
            .Planes
            .Any(p => p.Id == planeId);

        public FlightServiceModel Details(int flightId)
            => this.data
            .Flights
            .Where(f => f.Id == flightId)
            .ProjectTo<FlightServiceModel>(this.mapper)
            .FirstOrDefault();
    }
}
