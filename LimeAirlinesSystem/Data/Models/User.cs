namespace LimeAirlinesSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(CategoryAndPassangerMaxLength)]
        public string FullName { get; set; }


    }
}
