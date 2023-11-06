using AirFiel_Mariana_Oliveira.Data.Entities;
using AirFiel_Mariana_Oliveira.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AirFiel_Mariana_Oliveira.Helpers
{
    public interface IUserHelper
    {
        Task<Users> GetUserByUserNameAsync(string userName);

        Task<Users> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(Users user, string password);//Vai receber o user que quero criar e a password

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogOutAsync();

        Task<IdentityResult> UpdateUSerAsync(Users user); //Update o user first name and last

        Task<IdentityResult> ChangePasswordAsync(Users user, string oldPassword, string newPassword); //Mudar a pass, compará-la com a antiga e substituir.

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(Users user, string roleName);

        Task<bool> IsUserInRoleAsync(Users user, string roleName);

        Task<SignInResult> ValidatePasswordAsync(Users user, string password); 

        Task<string> GenerateEmailConfirmationTokenAsync(Users user); 

        Task<IdentityResult> ConfirmEmailAsync(Users user, string token); 

        Task<Users> GetUserByIdAsync(string userId); 

        Task<string> GeneratePasswordResetTokenAsync(Users user); 

        Task<IdentityResult> ResetPasswordAsync(Users user, string token, string password);
    }
}
