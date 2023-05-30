using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AlAnon.Data
{
    public class ApplicationUser : IdentityUser 
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Grupo { get; set; }
    }
}
