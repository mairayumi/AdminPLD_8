using Microsoft.AspNetCore.Mvc;
using System;
using waPLD_8.Models.Shared;
using waPLD_8.Models.ARMOR;
using waPLD_8.Extesion;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace waPLD_8.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class Persona_DocumentoController : ControllerBase
    {

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            Respuesta respuesta = new Respuesta();
            respuesta.exito = 1;
            respuesta.mensaje = "Sitio Operando Adecuadamente";
            return Ok(respuesta);
        }
        // POST api/<Personas_RelacionadasOutController>/{DbName}
        //[Authorize(Roles = "User")]
        [HttpPost("{DBName}")] //Pide el valor Nombrado
        public IActionResult Post([FromBody] IList<Persona_Documento> value, string DBName)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = value.CreateLocal("adswPolonia", "dbKYC_TP_" + DBName);
            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = ex.Message;
                return BadRequest(respuesta);
            }
            return Ok(respuesta);
        }
    }
}
