using AirFiel_Mariana_Oliveira.Data.Entities;
using AirFiel_Mariana_Oliveira.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

            #region

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

                if (!_context.Employee.Any())
                {
                    AddEmployees("Paula", "Coelho", "39", "paulacoelho@yopmail.com", "paulacoelho@yopmail.com", "915603003", "CoPilot");
                    AddEmployees("João", "Bola", "45", "joaobola@yopmail.com", "joaobola@yopmail.com", "938741258", "Pilot");

                    await _context.SaveChangesAsync();
                }

                if (!_context.City.Any())
                {
                    AddCities("Penafiel", "Portugal", "Very Charismatic", "AirFiel");
                    AddCities("Madrid", "Espanha", "Very busy", "MadridPort");

                    await _context.SaveChangesAsync();
                }

                if (!_context.airplanes.Any())
                {
                    AddPlanes("Airbus 500", 2, 200, 250);
                    AddPlanes("Boeing 777", 2, 300, 350);

                    await _context.SaveChangesAsync();
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

            if(!_context.Employee.Any())
            {
                AddEmployees("Paula","Coelho", "39","paulacoelho@yopmail.com","paulacoelho@yopmail.com","915603003", "CoPilot");
                AddEmployees("João", "Bola", "45", "joaobola@yopmail.com", "joaobola@yopmail.com", "938741258", "Pilot");

                await _context.SaveChangesAsync();
            }

            if(!_context.City.Any())
            {
                AddCities("Penafiel", "Portugal", "Very Charismatic", "AirFiel");
                AddCities("Madrid", "Espanha", "Very busy", "MadridPort");

                await _context.SaveChangesAsync();
            }

            if(!_context.airplanes.Any())
            {
                AddPlanes("Airbus 500", 2, 200, 250);
                AddPlanes("Boeing 777", 2, 300, 350);

                await _context.SaveChangesAsync();
            }
            #endregion
        }

        private void AddEmployees(string firstName, string lastName, string age, string email, string userName, string phoneNumber, string experience)
        {
            _context.Employee.Add(new Employees
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Email = email,
                UserName = userName,
                PhoneNumber = phoneNumber,
                Experience = experience
            });
        }

        private void AddCities(string city, string country, string description, string airport)
        {
            _context.City.Add(new Cities
            {
                Name = city,
                CountryName = country,
                Description = description,
                Airport = airport
            });
        }

        private void AddPlanes(string name, int classes, int capacity1, int capacity2)
        {
            _context.airplanes.Add(new Airplanes
            {
                Name = name,
                HowManyClasses = classes,
                Capacity1 = capacity1,
                Capacity2 = capacity2
            });
        }
    }
}
