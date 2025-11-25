using Microsoft.AspNetCore.Mvc;
using waPLD_8.Models.Shared;
using waPLD_8.Extesion;
using waPLD_8.Models.Bitacora;
using System;


namespace waPLD_8.Controllers
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
