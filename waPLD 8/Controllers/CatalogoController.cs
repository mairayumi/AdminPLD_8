using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using waPLD.Extesion;
using waPLD.Models.Catalogo;
using waPLD.Models.Shared;
using waPLD.Models.Solicitudes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace waPLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        // GET api/<CatalogoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                Catalogo catalogo = new Catalogo();
                catalogo.cCAT_Id = id;
                respuesta = catalogo.Read();
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
