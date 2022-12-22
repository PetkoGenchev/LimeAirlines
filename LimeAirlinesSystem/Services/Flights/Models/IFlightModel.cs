namespace LimeAirlinesSystem.Services.Flights.Models
{
    public interface IFlightModel
    {
        public string StartLocation { get; }
        public string EndLocation { get; }
        public int Price { get; }
    }
}
