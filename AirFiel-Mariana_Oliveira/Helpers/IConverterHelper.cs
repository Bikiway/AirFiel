using AirFiel_Mariana_Oliveira.Data.Entities;
using AirFiel_Mariana_Oliveira.Models;
using System;

namespace AirFiel_Mariana_Oliveira.Helpers
{
    public interface IConverterHelper
    {
        Airplanes ToPlanes(PlanesViewModel model, string imageId, bool isNew);
        PlanesViewModel ToPlanesViewModel(Airplanes planes);


        //City converter helper
        Cities ToCities(CitiesViewModel model, string imageId, bool isNew);
        CitiesViewModel ToCitiesViewModel(Cities cities);

        //Employee converter helper
        Employees ToEmployee(EmployeeViewModel model, string imageId, bool isNew);
        EmployeeViewModel ToEmployeeViewModel(Employees employees);
    }
}
