using AirFiel_Mariana_Oliveira.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AirFiel_Mariana_Oliveira.Data
{
    public class EmployeeRepository : GenericRepository<Employees>, IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context ) : base( context )
        {
            _context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return _context.Employee.Include(p => p.Users);
        }

        public IEnumerable<SelectListItem> GetComboEmployees()
        {
            var list = _context.Employee.Select(p => new SelectListItem
            {
                Text = p.EmployeeFullName,
                Value = p.Id.ToString(),
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select an Employee)",
                Value = "0",
            });

            return list;
        }
    }
}
