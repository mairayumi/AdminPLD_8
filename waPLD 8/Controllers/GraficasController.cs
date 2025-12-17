using Microsoft.AspNetCore.Mvc;
using waPLD.Models.Shared;
using waPLD.Extesion;
using waPLD.Models.Bitacora;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace waPLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraficasController : ControllerBase
    {
        // GET: api/<GraficasController>
        [HttpGet]
        public IActionResult Get(int cTLS_Id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                Graficas graficas = new Graficas();
                graficas.cTLS_Id = cTLS_Id;
                respuesta = graficas.Read();
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
