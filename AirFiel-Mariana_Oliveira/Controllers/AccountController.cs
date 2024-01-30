using AirFiel_Mariana_Oliveira.Data.Entities;
using AirFiel_Mariana_Oliveira.Helpers;
using AirFiel_Mariana_Oliveira.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using AirFiel_Mariana_Oliveira.Data;

namespace AirFiel_Mariana_Oliveira.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserHelper _userHelper;
        private readonly IConfiguration _configuration;
        private readonly IMailHelper _mailHelper;
        private readonly IRoutesRepository _routesRepository;
        private readonly ITicketsRepository _ticketsRepository;

        public AccountController(IUserHelper userHelper, IMailHelper mailHelper, IConfiguration configuration, IRoutesRepository routesRepository, ITicketsRepository ticketsRepository)
        {
            _userHelper = userHelper;
            _mailHelper = mailHelper;
            _configuration = configuration;
            _routesRepository = routesRepository;
            _ticketsRepository = ticketsRepository;

        }

        public async Task<IActionResult> UserSpace(UserSpaceViewModel model, int Id)
        {
            var user = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);
           // var ticketBought = _ticketsRepository.ReservationConfirmed(model);

            var getTicket = await _ticketsRepository.GetAllTicketsAsync(this.User.Identity.Name);

            if (user != null)
            {
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.UserName = user.UserName;
                model.Origin = getTicket.FirstOrDefault()?.Origin ?? null;
                model.Destination = getTicket.FirstOrDefault()?.Destination ?? null;
                model.Depart = getTicket.FirstOrDefault()?.Depart.ToShortTimeString() ?? null;
                model.Return = getTicket.FirstOrDefault()?.Return.ToShortDateString() ?? null;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UserSpace(UserSpaceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);

                if (user != null)
                {
                    // Update the user's information based on the changes made in the model
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.UserName = model.UserName;

                    // Save the updated user information
                    var result = await _userHelper.UpdateUSerAsync(user);

                    if (result.Succeeded)
                    {
                        // Update was successful, you can display a success message or redirect
                        return RedirectToAction("UserSpace");
                    }
                    else
                    {
                        // If the update failed, add the errors to the ModelState for display
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User not found.");
                }
            }

            // If ModelState is not valid or if there was an error, return to the same view
            return View(model);
        }



        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userHelper.LoginAsync(model);

                if (result.Succeeded)
                {
                    if (this.Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(this.Request.Query["ReturnUrl"].First());
                    }
                    return this.RedirectToAction("Index", "Home");
                }
            }

            this.ModelState.AddModelError(string.Empty, "Failed to login...");
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await _userHelper.LogOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterNewUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.GetUserByEmailAsync(model.UserName);

                if (user == null)
                {
                    user = new Users
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.UserName,
                        UserName = model.UserName,
                        PhoneNumber = model.PhoneNumber,
                        Age = model.Age,
                    };

                    var result = await _userHelper.AddUserAsync(user, model.Password);
                    if (result != IdentityResult.Success)
                    {
                        ModelState.AddModelError(string.Empty, "Sorry, the user couldn't be created...");
                        return View(model);
                    }

                    string myToken = await _userHelper.GenerateEmailConfirmationTokenAsync(user); 
                    string tokenLink = Url.Action("ConfirmEmail", "Account", new   
                    {
                        userid = user.Id,
                        token = myToken
                    }, protocol: HttpContext.Request.Scheme); 


                    Response response = _mailHelper.SendEmail(model.UserName, "AirFiel - Email Confirmation", $"<h1>Email Confirmation</h1>" +
                        $"<h2>Thanks for joining us, to allow you in please click in the link underneed</h2>" +
                        $"</br>" +
                        $"</br>" +
                        $"<a href = \"{tokenLink}\">Confirm Email</a>");

                    if (response.IsSuccess)
                    {
                        await _userHelper.AddUserToRoleAsync(user, "Customer");
                        await _userHelper.CheckRoleAsync("Customer");
                        ViewBag.Message = "The email has been sent.";
                        return View(model);
                    }

                    ModelState.AddModelError(string.Empty, "The user couldn't be logged.");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> ChangeUser()
        {
            var user = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);
            var model = new ChangeUserViewModel();

            if (user != null)
            {
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.Age = user.Age;
                model.PhoneNumber = user.PhoneNumber;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeUser(ChangeUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);

                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.PhoneNumber = model.PhoneNumber;
                    user.Age = model.Age;

                    var response = await _userHelper.UpdateUSerAsync(user);

                    if (response.Succeeded)
                    {
                        ViewBag.UserMessage = "User updated successfuly";
                    }
                    else { ModelState.AddModelError(string.Empty, response.Errors.FirstOrDefault().Description); }
                }
            }
            return View(model);
        }

        public IActionResult ChangePassword()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);

                if (user != null)
                {
                    var response = await _userHelper.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

                    if (response.Succeeded)
                    {
                        return this.RedirectToAction("ChangeUser");
                    }
                    else
                    {
                        this.ModelState.AddModelError(string.Empty, response.Errors.FirstOrDefault().Description);
                    }
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, "User not found");
                }
            }

            return this.View(model);
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


        public IActionResult RecoverPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RecoverPassword(RecoverPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.GetUserByEmailAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "The email doensn't correspond to a registered email user");
                    return View(model); //Não deixar os campos vazios novamente.
                }

                var myToken = await _userHelper.GeneratePasswordResetTokenAsync(user);

                var link = Url.Action(
                    "ResetPassword",
                    "Account",
                    new { token = myToken }, protocol: HttpContext.Request.Scheme);

                Response response = _mailHelper.SendEmail(model.Email, "SuperShop Password Reset", $"<h1>SuperShop forgot your Password?</h1>" +
                    $"To reset it, please click in this link:</br></br>" +
                    $"<a href= \"{link}\"> Reset Password</a>");

                if (response.IsSuccess)
                {
                    ViewBag.Message = "The instructions to recover your password has been sent to the email associated.";
                }

                return View();
            }
            return View(model);
        }

        public IActionResult ResetPassword(string token)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            var user = await _userHelper.GetUserByEmailAsync(model.UserName);
            if (user != null)
            {
                var result = await _userHelper.ResetPasswordAsync(user, model.Token, model.Password);
                if (result.Succeeded)
                {
                    ViewBag.Message = "Your Password has been successfuly reset it";
                    return View();
                }

                ViewBag.Message = "Error while resetting your password...";
                return View();
            }

            ViewBag.Message = "User Not Found!";
            return View(model);
        }

        public IActionResult NotAuthorized()
        {
            return View();
        }
    }
}
