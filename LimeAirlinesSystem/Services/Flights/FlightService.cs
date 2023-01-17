namespace LimeAirlinesSystem.Services.Flights
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using LimeAirlinesSystem.Data;
    using LimeAirlinesSystem.Data.Models;
    using LimeAirlinesSystem.Services.Flights.Models;
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
            string startLocation = null,
            string endLocation = null,
            string flightDateTime = null,
            int passangers = 0,
            string tripType = null,
            int currentPage = 1,
            int flightsPerPage = int.MaxValue,
            bool publicOnly = true)
        {
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

            if (!string.IsNullOrEmpty(flightDateTime))
            {
                flightQuery = flightQuery.Where(f => f.FlightDateTime == flightDateTime);
            }

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


        public int Create(string startLocation, string endLocation, string flightDateTime, int price, string imageUrl, int planeId)
        {
            var flightData = new Flight
            {
                StartLocation = startLocation,
                EndLocation = endLocation,
                FlightDateTime = flightDateTime,
                Price = price,
                ImageUrl = imageUrl,
                PlaneId = planeId,
                IsPublic = true
            };

            this.data.Flights.Add(flightData);
            this.data.SaveChanges();

            return flightData.Id;
        }

        public bool Edit(int flightId, string startLocation, string endLocation, string flightDateTime, int price, string imageUrl, int planeId, bool isPublic)
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
            flightData.FlightDateTime = flightDateTime;
            flightData.PlaneId  = planeId;
            flightData.ImageUrl = imageUrl;

            this.data.SaveChanges();

            return true;
        }

        public IEnumerable<string> AllDestinations()
            => this.data
            .Flights
            .Select(f => f.StartLocation)
            .Distinct()
            .OrderBy(br => br)
            .ToList();

        public IEnumerable<int> AllTripTypes()
            => this.data
            .TripTypes
            .Select(t => t.Id)
            .Distinct()
            .OrderBy(br => br)
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

        public IEnumerable<FlightServiceModel> MyFlights(string userId)
            => GetFlights(this.data
                .Flights
                .Where(f => f.Passangers.Any(c => c.Id == userId)));
    }
}
