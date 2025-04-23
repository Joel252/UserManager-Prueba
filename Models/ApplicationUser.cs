using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace UserManagerPrueba.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Nombre completo")]
        public string FullName { get; set; }
    }
}
