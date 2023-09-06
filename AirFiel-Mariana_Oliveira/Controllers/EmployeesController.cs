using AirFiel_Mariana_Oliveira.Data;
using AirFiel_Mariana_Oliveira.Data.Entities;
using AirFiel_Mariana_Oliveira.Helpers;
using AirFiel_Mariana_Oliveira.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AirFiel_Mariana_Oliveira.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IImageHelper _imageHelper;
        private readonly IUserHelper _userHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly IMailHelper _mailHelper;
        private readonly IConfiguration _configuration;

        public EmployeesController(IUserHelper userHelper, IConverterHelper converterHelper, IImageHelper imageHelper, IEmployeeRepository employeeRepository, IMailHelper mailHelper, IConfiguration configuration)
        {
            _userHelper = userHelper;
            _converterHelper = converterHelper;
            _imageHelper = imageHelper;
            _employeeRepository = employeeRepository;
            _mailHelper = mailHelper;
            _configuration = configuration;
        }

        // GET: Employees
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(_employeeRepository.GetAllWithUser().OrderBy(o => o.Experience));
        }

        // GET: Employees/Details/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel model, ChangeEmployeeUserViewModel register)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.GetUserByEmailAsync(register.UserName);

                if (user == null)
                {
                    // var IdEmploy = await _userHelper.GetUserByIdAsync(user.Id);

                    user = new Users
                    {
                        //Id = change.UserName,
                        FirstName = register.FirstName,
                        LastName = register.LastName,
                        Email = register.UserName,
                        UserName = register.UserName,
                        Age = register.Age,
                        PhoneNumber = register.PhoneNumber,
                        Experience = register.Experience,
                        ImageUserProfile = register.ProfileImage,
                    };

                    //Caso não consiga criar um login novo

                    var result = await _userHelper.AddUserAsync(user, register.Password);
                    if (result != IdentityResult.Success)
                    {
                        ModelState.AddModelError(string.Empty, "The user couldn't be created.");
                        return View(register);
                    }

                    //Image
                    var path = string.Empty;

                    if (register.ProfileImage != null && register.ProfileImage.Length > 0)
                    {
                        path = await _imageHelper.UploadImageAsync(model.ImageProfile, "employees");
                    }

                    //Token Email
                    string myToken = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                    string tokenLink = Url.Action("ConfirmEmail", "Employees", new
                    {
                        userid = user.Id,
                        token = myToken
                    }, protocol: HttpContext.Request.Scheme);


                    Response response = _mailHelper.SendEmail(register.UserName, "Email Confirmation AirFiel", $"<h1>Employee Email Confirmation</h1>" +
                        $"<h2>Welcome to our team!</h2>" +
                        $"<h3>Please click in this link</h3>" +
                        $"</br>" +
                        $"</br>" +
                        $"<a href = \"{tokenLink}\">Confirm Employee Email</a>");

                    if (response.IsSuccess)
                    {
                        ViewBag.Message = "The email has been sent.";

                        var employees = _converterHelper.ToEmployee(register, model, path, true);

                        employees.Users = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                        await _employeeRepository.CreateAsync(employees);

                        return View(register);
                    }



                }


                ModelState.AddModelError(string.Empty, "The user couldn't be logged.");

            }
            return View(register);
        }



        // GET: Employees/Edit/5
        [Authorize(Roles = "Admin")]
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
        public async Task<IActionResult> Edit(EmployeeViewModel model)
        {
            var user = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);
            var models = new ChangeEmployeeUserViewModel();

            if (user != null)
            {
                try
                {
                    models.FirstName = user.FirstName;
                    models.LastName = user.LastName;
                    models.Age = user.Age;
                    models.PhoneNumber = user.PhoneNumber;
                    model.ProfileImage = user.ImageUserProfile;

                    var path = model.ProfileImage;

                    if (model.ImageProfile != null && model.ImageProfile.Length > 0)
                    {
                        path = await _imageHelper.UploadImageAsync(model.ImageProfile, "employees");
                    }

                    var employees = _converterHelper.ToEmployee(models, model, path, false);

                    employees.Users = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                    await _employeeRepository.UpdateAsync(employees);


                    var response = await _userHelper.UpdateUSerAsync(user);

                    if (response.Succeeded)
                    {
                        ViewBag.UserMessage = "User updated!";
                    }
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
        [Authorize(Roles = "Admin")]
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


        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody] LoginViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = await _userHelper.GetUserByEmailAsync(model.UserName);
                if (user != null)
                {
                    var result = await _userHelper.ValidatePasswordAsync(
                        user,
                        model.Password);
                    if (result.Succeeded)
                    {
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"])); //Algoritmo para ir buscar a key (No appsettings.json).
                        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); //Gerar o token, usando o algoritmo que vem do security key. 256 bits. Depende do middleware.
                        var token = new JwtSecurityToken(
                            _configuration["Tokens:Issuer"],
                            _configuration["Tokens:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddDays(15),
                            signingCredentials: credentials);
                        var results = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        };

                        return this.Created(string.Empty, results);
                    }
                }
            }
            return BadRequest();
        }


        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                return NotFound();
            }

            var user = await _userHelper.GetUserByIdAsync(userId); //Verificar se tem user
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userHelper.ConfirmEmailAsync(user, token); //Vê se está tudo Okay.

            if (!result.Succeeded)
            {
                return NotFound();
            }

            return View();
        }




        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_employeeRepository == null)
            {
                return Problem("Entity set 'DataContext.employees' is null");
            }

            var employees = await _employeeRepository.GetByIdAsync(id);

            if (employees != null)
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
