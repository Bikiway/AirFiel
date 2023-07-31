﻿using AirFiel_Mariana_Oliveira.Data.Entities;
using AirFiel_Mariana_Oliveira.Models;
using System;

namespace AirFiel_Mariana_Oliveira.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public Cities ToCities(CitiesViewModel model, string imageId, bool isNew)
        {
            return new Cities
            {
                Id = isNew ? 0 : model.Id,
                Name = model.Name,
                Flags = imageId,
                Airport = model.Airport,
                CountryName = model.CountryName,
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
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ProfileImage = imageId,
                Age = model.Age,
                Experience = model.Experience,
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
                ProfileImage = employees.ProfileImage,
                Age = employees.Age,
                Experience = employees.Experience,
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
