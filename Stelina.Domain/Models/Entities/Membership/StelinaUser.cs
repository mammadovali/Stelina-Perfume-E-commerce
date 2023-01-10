using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Stelina.Domain.Models.Entities.Membership
{
    public class StelinaUser : IdentityUser<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
    }
}
