namespace LimeAirlinesSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Passanger;
    public class Passanger : IdentityUser
    {
        [Required]
        [MaxLength(PassangerMaxLength)]
        public string FullName { get; set; }


        public IEnumerable<Flight> Flights = new List<Flight>();
    }
}
