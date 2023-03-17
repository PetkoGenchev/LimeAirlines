﻿using System;

namespace LimeAirlinesSystem.Services.Flights.Models
{
    public class FlightServiceModel : IFlightModel
    {
        public int Id { get; init; }

        public string StartLocation { get; init; }

        public string EndLocation { get; init; }

        public string FlightDate { get; init; }

        public string FlightDuration { get; init; }

        public int Transfer { get; init; }

        public int Price { get; init; }

        public int ReservedSeats { get; init; }

        public string ImageUrl { get; init; }

        public bool IsPublic { get; init; }


    }
}
