﻿using AirFiel_Mariana_Oliveira.Data.Entities;
using AirFiel_Mariana_Oliveira.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AirFiel_Mariana_Oliveira.Helpers
{
    public interface IUserHelper
    {
        Task<Users> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(Users user, string password);//Vai receber o user que quero criar e a password

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogOutAsync();

        Task<IdentityResult> UpdateUSerAsync(Users user); //Update o user first name and last

        Task<IdentityResult> ChangePasswordAsync(Users user, string oldPassword, string newPassword); //Mudar a pass, compará-la com a antiga e substituir.
        Task CheckRoleAsync(string roleName);
        Task AddUserToRoleAsync(Users user, string roleName);
        Task<bool> IsUserInRoleAsync(Users user, string roleName);
    }
}
