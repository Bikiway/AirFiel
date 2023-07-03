using Microsoft.AspNetCore.Identity;

namespace AirFiel_Mariana_Oliveira.Data.Entities
{
    public class Users : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
