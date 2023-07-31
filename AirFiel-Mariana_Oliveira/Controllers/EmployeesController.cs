using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirFiel_Mariana_Oliveira.Data;
using AirFiel_Mariana_Oliveira.Data.Entities;
using AirFiel_Mariana_Oliveira.Helpers;
using AirFiel_Mariana_Oliveira.Models;

namespace AirFiel_Mariana_Oliveira.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IImageHelper _imageHelper;
        private readonly IUserHelper _userHelper;
        private readonly IConverterHelper _converterHelper;

        public EmployeesController(IUserHelper userHelper, IConverterHelper converterHelper, IImageHelper imageHelper, IEmployeeRepository employeeRepository)
        {
            _userHelper = userHelper;
            _converterHelper = converterHelper;
            _imageHelper = imageHelper;
            _employeeRepository = employeeRepository;
        }

        // GET: Employees
        public IActionResult Index()
        {
            return View(_employeeRepository.GetAllWithUser().OrderBy(e => e.FirstName));
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("EmployeeNotFound");
            }

            var employees = await _employeeRepository.GetByIdAsync(id.Value);

            if (employees == null)
            {
                return new NotFoundViewResult("EmployeeNotFound");
            }

            return View(employees);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if(model.ImageProfile != null && model.ImageProfile.Length > 0)
                {
                    path = await _imageHelper.UploadImageAsync(model.ImageProfile, "employees");
                }

                var employees = _converterHelper.ToEmployee(model, path, true);

                employees.Users = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                await _employeeRepository.CreateAsync(employees);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("EmployeeNotFound");
            }

            var employees = await _employeeRepository.GetByIdAsync(id.Value);

            if (employees == null)
            {
                return new NotFoundViewResult("EmployeeNotFound");
            }

            var model = _converterHelper.ToEmployeeViewModel(employees);
            return View(model);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var path = model.ProfileImage;

                    if(model.ImageProfile != null && model.ImageProfile.Length > 0)
                    {
                        path = await _imageHelper.UploadImageAsync(model.ImageProfile, "employees");
                    }

                    var employees = _converterHelper.ToEmployee(model, path, false);

                    employees.Users = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                    await _employeeRepository.UpdateAsync(employees);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _employeeRepository.ExistAsync(model.Id))
                    {
                        return new NotFoundViewResult("EmployeeNotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("EmployeeNotFound");
            }

            var employees = await _employeeRepository.GetByIdAsync(id.Value);

            if (employees == null)
            {
                return new NotFoundViewResult("EmployeeNotFound");
            }

            return View(employees);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if(_employeeRepository == null)
            {
                return Problem("Entity set 'DataContext.employees' is null");
            }

            var employees = await _employeeRepository.GetByIdAsync(id);

            if(employees != null)
            {
                await _employeeRepository.DeleteAsync(employees);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult EmployeeNotFound()
        {
            return View();
        }
    }
}
