using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace LimeAirlinesSystem.Models.Flights
{
    public class AllFlightsQueryModel
    {
        public string StartLocation { get; init; }
        public string EndLocation { get; init; }
        public string FlightStartDate { get; init; }
        public string FlightEndDate { get; init; }
        public string Plane { get; init; }
    }
}
