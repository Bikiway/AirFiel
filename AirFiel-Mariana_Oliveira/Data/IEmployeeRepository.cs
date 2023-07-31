using AirFiel_Mariana_Oliveira.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AirFiel_Mariana_Oliveira.Data
{
    public interface IEmployeeRepository : IGenericRepository<Employees>
    {
        public IQueryable GetAllWithUsers();

        IEnumerable<SelectListItem> GetComboEmployees();
    }
}
