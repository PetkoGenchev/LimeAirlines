﻿namespace LimeAirlinesSystem.Services.Flights.Models
{
    using System;

    public class FlightServiceModel : IFlightModel
    {
        public int Id { get; init; }

        public string StartLocation { get; init; }

        public string EndLocation { get; init; }

        public string FlightDateTime { get; init; }

        public int Price { get; init; }

        public string ImageUrl { get; init; }

        public bool IsPublic { get; init; }

    }
}
