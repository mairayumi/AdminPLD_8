using Microsoft.AspNetCore.Mvc;
using System;
using waPLD.Models.Shared;
using waPLD.Models.ARMOR;
using waPLD.Extesion;
using System.Drawing;
using System.IO.Pipelines;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace waPLD.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class Personas_RelacionadasController : ControllerBase
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

        //[HttpPost("{Nombrado}")] Pide el valor Nombrado
        // POST api/<Personas_RelacionadasOutController>/{DbName}
        //[Authorize(Roles = "User")]
        [HttpPost("{DBName}")] //Pide el valor Nombrado
        public IActionResult Post([FromBody] IList<Personas_Relacionadas> value, string DBName)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = value.CreateLocal("adswPolonia", "dbKYC_TP_"+DBName);
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
