using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using waPLD_8.Extesion;
using waPLD_8.Models.Catalogo;
using waPLD_8.Models.Shared;
using waPLD_8.Models.Solicitudes;

namespace waPLD_8.Controllers
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
