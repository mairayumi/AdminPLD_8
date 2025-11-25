using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using waPLD_8.Models.Shared;
using waPLD_8.Models.Bitacora;
using waPLD_8.Extesion;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace waPLD_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncOficioController : ControllerBase
    {
        // GET: api/<OficiosController>
        [HttpGet]
        public IActionResult Get(int Id, int Año, int Tipo, int PagAct)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                EncOficio oficios = new EncOficio();
                oficios.lOFD_Id = Id;
                oficios.lOFD_Año = Año;
                oficios.lOFD_Tipo = Tipo;
                oficios.PagAct = PagAct;
                respuesta = oficios.Read();
            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = ex.Message;
                return BadRequest(respuesta);
            }
            return Ok(respuesta);
        }

        // GET api/<OficiosController>/5
        //[HttpGet("{id}")]
    }
}
