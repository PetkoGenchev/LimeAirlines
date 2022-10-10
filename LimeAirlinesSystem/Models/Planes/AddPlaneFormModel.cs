using LimeAirlinesSystem.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LimeAirlinesSystem.Models.Planes
{
    public class AddPlaneFormModel
    {
        public string Brand { get; init; }

        public string Model { get; init; }

        public int NumberOfSeats { get; init; }

        public int ImageUrl { get; init; }

        public int Year { get; init; }
    }
}




