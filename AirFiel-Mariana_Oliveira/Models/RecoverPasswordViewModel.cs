using System.ComponentModel.DataAnnotations;

namespace AirFiel_Mariana_Oliveira.Models
{
    public class RecoverPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
