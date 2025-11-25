using Microsoft.AspNetCore.Mvc;
using System;
using waPLD_8.Extesion;
using waPLD_8.Models.Bitacora;
using waPLD_8.Models.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace waPLD_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoListaController : ControllerBase
    {
        //[HttpGet("{cTLS_Id}")]
        [HttpGet]
        public IActionResult Get(int cTLS_Id, int PagAct, string Filtro, string Periodo)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                TipoLista tipoLista = new TipoLista();
                tipoLista.cTLS_Id = cTLS_Id;
                tipoLista.PagAct = PagAct;
                tipoLista.Filtro = Filtro;
                tipoLista.Periodo = Periodo;

                respuesta = tipoLista.Read();
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
