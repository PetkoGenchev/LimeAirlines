using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LimeAirlinesSystem.Models.Home
{
    public class IndexViewModel
    {
        [Display(Name = "Trip")]
        public string TripType { get; init; }

        public List<FlightIndexViewModel> Flights { get; init; }
    }
}
