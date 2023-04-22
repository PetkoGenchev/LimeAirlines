namespace LimeAirlinesSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.PassangerConstants;
    public class Passanger : IdentityUser
    {
        [Required]
        [MaxLength(PassangerMaxLength)]
        public string FullName { get; set; }

        public string PublicId { get; init; } = Guid.NewGuid().ToString();

        public IEnumerable<Flight> Flights { get; init; } = new List<Flight>();
    }
}
   