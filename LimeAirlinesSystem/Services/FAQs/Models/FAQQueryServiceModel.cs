using LimeAirlinesSystem.Services.Flights.Models;
using LimeAirlinesSystem.Services.Information.Models;
using System.Collections.Generic;

namespace LimeAirlinesSystem.Services.FAQs.Models
{
    public class FAQQueryServiceModel
    {
        public IEnumerable<FAQServiceModel> FAQs { get; set; }
    }
}
