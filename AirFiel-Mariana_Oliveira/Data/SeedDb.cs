using AirFiel_Mariana_Oliveira.Data.Entities;
using AirFiel_Mariana_Oliveira.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
            await _context.Database.MigrateAsync();

            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Employees");
            await _userHelper.CheckRoleAsync("Customer");
            await _userHelper.CheckRoleAsync("Anonymous");

            #region

                var resulted = await _userHelper.AddUserAsync(null, null);

                if (resulted != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the anonymous user in Seeder");
                }

                var isRole = await _userHelper.IsUserInRoleAsync(null, "Anonymous");
                if (!isRole)
                {
                    await _userHelper.AddUserToRoleAsync(null, "Anonymous");
                }
            

            #endregion

            #region
            var employee = await _userHelper.GetUserByEmailAsync("sararibeiro@yopmail.com");
            if (employee == null)
            {
                employee = new Users
                {
                    FirstName = "Sara",
                    LastName = "Ribeiro",
                    Email = "sararibeiro@yopmail.com",
                    UserName = "sararibeiro@yopmail.com",
                    PhoneNumber = "913265987",
                    Age = "31",
                    Experience = "HR Director",
                };

                var result = await _userHelper.AddUserAsync(employee, "123456");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create employee in seeder");
                }

                await _userHelper.AddUserToRoleAsync(employee, "Employees");
                var tokens = await _userHelper.GenerateEmailConfirmationTokenAsync(employee);
                await _userHelper.ConfirmEmailAsync(employee, tokens);

                var inRole = await _userHelper.IsUserInRoleAsync(employee, "Employees");
                if (inRole)
                {
                    await _userHelper.AddUserToRoleAsync(employee, "Employees");
                }
            }
            #endregion
            #region
            var user = await _userHelper.GetUserByEmailAsync("mariana.95@outlook.pt");
            if (user == null)
            {
                user = new Users
                {
                    FirstName = "Mariana",
                    LastName = "Oliveira",
                    Email = "mariana.95@outlook.pt",
                    UserName = "mariana.95@outlook.pt",
                    PhoneNumber = "123456789",
                    Age = "27",
                    Experience = "Administrator",
                };

                var result = await _userHelper.AddUserAsync(user, "123456");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in Seeder");
                }

                await _userHelper.AddUserToRoleAsync(user, "Admin");
                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);
            }

            var isInRole = await _userHelper.IsUserInRoleAsync(user, "Admin");
            if (isInRole)
            {
                await _userHelper.AddUserToRoleAsync(user, "Admin");
            }
            #endregion
        }
    }
}
