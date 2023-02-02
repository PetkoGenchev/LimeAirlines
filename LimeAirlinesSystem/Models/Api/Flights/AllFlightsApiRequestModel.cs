﻿using LimeAirlinesSystem.Services.Flights.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace LimeAirlinesSystem.Models.Api.Flights
{
    public class AllFlightsApiRequestModel
    {
        public string TripType { get; init; }
        public string StartLocation { get; init; }
        public string EndLocation { get; init; }
        public string FlightDateTime { get; init; } = DateTime.UtcNow.ToString();
        public int Passangers { get; init; }
        public int CurrentPage { get; init; } = 1;

        public const int FlightsPerPage = 10;
    }
}