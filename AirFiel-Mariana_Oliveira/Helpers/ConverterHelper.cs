using AirFiel_Mariana_Oliveira.Data.Entities;
using AirFiel_Mariana_Oliveira.Models;
using System;
using System.Collections.Generic;

namespace AirFiel_Mariana_Oliveira.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public Cities ToCities(CitiesViewModel model, string flags, bool isNew)
        {
            return new Cities
            {
                Id = isNew? 0 : model.Id,
                Name = model.Name,
                CountryName = model.CountryName,
                Flags = flags,
                Airport = model.Airport,
                Description = model.Description,
                Users = model.Users,
            };
        }

        public CitiesViewModel ToCitiesViewModel(Cities cities)
        {
            return new CitiesViewModel
            {
                Id = cities.Id,
                Name = cities.Name,
                Flags = cities.Flags,
                Airport = cities.Airport,
                CountryName = cities.CountryName,
                Description = cities.Description,
                Users = cities.Users,
            };
        }

        public Employees ToEmployee(EmployeeViewModel model, string imageId, bool isNew)
        {
            return new Employees
            {
                Id =isNew ? 0 : model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                ProfileImage = imageId,
                Age = model.Age,
                Experience = model.Experience,
                Email = model.UserName,
                UserName = model.UserName,
                Users = model.Users,
            };
        }

        public EmployeeViewModel ToEmployeeViewModel(Employees employees)
        {
            return new EmployeeViewModel
            {
                Id = employees.Id,
                FirstName = employees.FirstName,
                LastName = employees.LastName,
                PhoneNumber = employees.PhoneNumber,
                ProfileImage = employees.ProfileImage,
                Age = employees.Age,
                Experience = employees.Experience,
                Email= employees.Email,
                UserName = employees.UserName,
                Users = employees.Users,
            };
        }

        public Airplanes ToPlanes(PlanesViewModel model, string imageId, bool isNew)
        {
            return new Airplanes
            {
                Id = isNew ? 0 : model.Id,
                Name = model.Name,
                ImagePlane = imageId,
                users = model.users,
                Capacity1 = model.Capacity1,
                Capacity2 = model.Capacity2,
                HowManyClasses = model.HowManyClasses,
            };
        }

        public PlanesViewModel ToPlanesViewModel(Airplanes planes)
        {
            return new PlanesViewModel
            {
                Id = planes.Id,
                Name = planes.Name,
                ImagePlane = planes.ImagePlane,
                users = planes.users,
                Capacity1 = planes.Capacity1,
                Capacity2 = planes.Capacity2,
                HowManyClasses = planes.HowManyClasses,
            };
        }
    }
}
