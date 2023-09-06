using AirFiel_Mariana_Oliveira.Data.Entities;
using AirFiel_Mariana_Oliveira.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace AirFiel_Mariana_Oliveira.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Employees");
            await _userHelper.CheckRoleAsync("Customer");

            var user = await _userHelper.GetUserByEmailAsync("mariana.95@outlook.pt");
            if(user == null)
            {
                user = new Users
                {
                    FirstName = "Mariana",
                    LastName = "Oliveira",
                    Email = "mariana.95@outlook.pt",
                    UserName = "mariana.95@outlook.pt",
                    DateOfBirth = DateTime.Parse(DateTime.Now.ToString("26/09/1995")),
                    PhoneNumber = "123456789",
                    Age= "27",
                    Experience="Administrator",
                };

                var result = await _userHelper.AddUserAsync(user, "123456");

                if(result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in Seeder");
                }

                await _userHelper.AddUserToRoleAsync(user, "Admin");
                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);
            }

            var isInRole = await _userHelper.IsUserInRoleAsync(user, "Admin");
            if(isInRole) 
            {
                await _userHelper.AddUserToRoleAsync(user, "Admin");
            }

           
        }
    }
}
