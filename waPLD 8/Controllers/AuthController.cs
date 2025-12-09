using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System;
using waPLD_8.Models.Catalogo.Usuario;
using waPLD_8.Models.Shared;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
// For more informatiossssddddn on ddddenabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace waPLD_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta respuesta = new Respuesta();
            respuesta.exito = 1;
            respuesta.mensaje = "Sitio Operando Adecuadamente";
            return Ok(respuesta);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                var token = _userService.Authenticate(user.Email, user.Password).Result.ToString();

                if (token == null)
                    return Unauthorized();

                respuesta.exito = 1;
                respuesta.Data = "{\"Token\" : \"" + token + "\"}";
            }
            catch (Exception)
            {
                respuesta.exito = 0;
                respuesta.mensaje = "El usuario no existe";
                //throw;
            }
            return Ok(respuesta);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] Usuarios user)
        {
            Respuesta respuesta = new Respuesta();
            var token = _userService.Alta(user.UserName, user.Password, user.Email).Result.ToString();
            respuesta.exito = 1;
            respuesta.Data = "{\"proceso\" : \"" + token + "\"}";
            return Ok(respuesta);
        }

    }
}