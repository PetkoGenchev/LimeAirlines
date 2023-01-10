namespace LimeAirlinesSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;
    public class Passanger : IdentityUser
    {
        [Required]
        [MaxLength(CategoryAndPassangerMaxLength)]
        public string FullName { get; set; }

        public IEnumerable<Flight> Flights = new List<Flight>();
    }
}
