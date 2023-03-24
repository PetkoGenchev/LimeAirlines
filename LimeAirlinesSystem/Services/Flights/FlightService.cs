﻿namespace LimeAirlinesSystem.Services.Flights
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using LimeAirlinesSystem.Data;
    using LimeAirlinesSystem.Data.Models;
    using LimeAirlinesSystem.Models;
    using LimeAirlinesSystem.Services.Flights.Models;
    using LimeAirlinesSystem.Services.Planes.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Components.Forms;
    using Microsoft.AspNetCore.Mvc;
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
            int currentPage = 1,
            int flightsPerPage = int.MaxValue)
        {

            var flightQuery = this.data.Flights;

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



            public FlightQueryServiceModel All(
            DateTime flightDate,
            string startLocation = null,
            string endLocation = null,
            int passangers = 1,
            string tripType = null,
            int maxTransfers = int.MaxValue,
            int maxPrice = int.MaxValue,
            FlightSorting sorting = FlightSorting.Duration,
            int currentPage = 1,
            int flightsPerPage = int.MaxValue,
            bool publicOnly = true)
        {

            foreach (var flight in this.data.Flights)
            {
                if (flight.FlightDate < DateTime.UtcNow)
                {
                    flight.IsPublic = false;

                }
            }
            this.data.SaveChanges();


            var flightQuery = this.data.Flights
                .Where(f => !publicOnly || f.IsPublic);


            if (!string.IsNullOrEmpty(startLocation))
            {
                flightQuery = flightQuery.Where(f => f.StartLocation == startLocation);
            }

            if (!string.IsNullOrEmpty(endLocation))
            {
                flightQuery = flightQuery.Where(f => f.EndLocation == endLocation);
            }

            flightQuery = flightQuery.Where(f => (f.ReservedSeats + passangers) <= f.Plane.NumberOfSeats);


            flightQuery = flightQuery.Where(f => f.FlightDate.Date == flightDate.Date);


            if (maxTransfers != int.MaxValue)
            {
                flightQuery = flightQuery.Where(f => f.Transfer <= maxTransfers);
            }


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



            var returnModel = new FlightQueryServiceModel
            {
                CurrentPage = currentPage,
                TotalFlights = totalFlights,
                FlightsPerPage = flightsPerPage,
                Flights = flights
            };


            if (tripType == "2")
            {
                var returnFlightQuery = this.data.Flights
                    .Where(f => !publicOnly || f.IsPublic);

                if (!string.IsNullOrEmpty(startLocation))
                {
                    returnFlightQuery = returnFlightQuery.Where(f => f.StartLocation == endLocation);
                }

                if (!string.IsNullOrEmpty(endLocation))
                {
                    returnFlightQuery = returnFlightQuery.Where(f => f.EndLocation == startLocation);
                }

                returnFlightQuery = returnFlightQuery.Where(f => (f.ReservedSeats + passangers) <= f.Plane.NumberOfSeats);


                returnFlightQuery = returnFlightQuery.Where(f => f.FlightDate.Date >= flightDate.Date.AddDays(2) && f.FlightDate.Date <= flightDate.AddDays(10));


                if (maxTransfers != int.MaxValue)
                {
                    returnFlightQuery = returnFlightQuery.Where(f => f.Transfer <= maxTransfers);
                }


                if (maxPrice != int.MaxValue)
                {
                    returnFlightQuery = returnFlightQuery.Where(f => f.Price <= maxPrice);
                }

                var returnFlights = GetFlights(returnFlightQuery
                    .Skip((currentPage - 1) * flightsPerPage)
                    .Take(flightsPerPage));

                returnModel.ReturnFlights = returnFlights;
            }

            return returnModel;
        }


        public int Create(
            string startLocation,
            string endLocation,
            DateTime flightDate,
            int price,
            string imageUrl,
            TimeSpan flightDuration,
            int transfer,
            int planeId)
        {
            var flightData = new Flight
            {
                StartLocation = startLocation,
                EndLocation = endLocation,
                FlightDate = flightDate,
                Price = price,
                ImageUrl = imageUrl,
                FlightDuration = flightDuration,
                Transfer = transfer,
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
            TimeSpan flightDuration,
            int planeId,
            int transfer,
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
            flightData.FlightDuration = flightDuration;
            flightData.Transfer = transfer;

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

            this.data.SaveChanges();
        }


        public IEnumerable<CheapestFlightServiceModel> Cheapest()
            => this.data
            .Flights
            .Where(f => f.IsPublic && f.FlightDate >= DateTime.UtcNow)
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
