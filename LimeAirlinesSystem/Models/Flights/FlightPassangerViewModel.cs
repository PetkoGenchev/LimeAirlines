using System.ComponentModel.DataAnnotations;

namespace LimeAirlinesSystem.Models.Flights
{
    public class FlightPassangerViewModel
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
