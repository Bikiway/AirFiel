using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AirFiel_Mariana_Oliveira.Data;

namespace AirFiel_Mariana_Oliveira.Controllers.API_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClientsController : Controller
    {
        private readonly ITicketsRepository _ticketsRepository;

        public ClientsController(ITicketsRepository ticketsRepository)
        {
            _ticketsRepository = ticketsRepository;
        }

        [HttpGet]
        public IActionResult GetClients() 
        {
            return Ok(_ticketsRepository.GetAllWithUsers());
        }
    }
}
