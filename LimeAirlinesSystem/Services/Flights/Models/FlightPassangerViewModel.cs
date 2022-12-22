using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace LimeAirlinesSystem.Services.Flights.Models
{
    public class FlightPassangerViewModel
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
