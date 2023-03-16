using LimeAirlinesSystem.Services.Flights.Models;
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
        public DateTime FlightDate { get; set; } = DateTime.UtcNow;
        public TimeSpan FlightDuration { get; init; }
        public int MaxTransfers { get; init; }
        public int MaxPrice { get; init; }
        public FlightSorting Sorting { get; init; }
        public int Passangers { get; init; }
        public int CurrentPage { get; init; } = 1;

        public int FlightsPerPage = 10;
    }
}