using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using waPLD.Models.Catalogo;
using waPLD.Models.Shared;
using waPLD.Extesion;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace waPLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusquedaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string sBusqueda, int PagAct)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                Busqueda busqueda = new Busqueda();
                busqueda.cBSQ_Persona= sBusqueda;
                busqueda.PagAct = PagAct;
                respuesta = busqueda.Read();
            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = ex.Message;
                return BadRequest(respuesta);
            }
            return Ok(respuesta);
        }

        // POST api/<BusquedaController>
        [HttpPost]
        public IActionResult Post([FromBody] Busqueda busqueda)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = busqueda.Create();
            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = ex.Message;
                return BadRequest(respuesta);
            }
            return Ok(respuesta);
        }

        // PUT api/<BusquedaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Busqueda busqueda)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = busqueda.Update();
            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = ex.Message;
                return BadRequest(respuesta);
            }
            return Ok(respuesta);
        }

        // DELETE api/<BusquedaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                Busqueda busqueda = new Busqueda();
                busqueda.cBSQ_Id = id;
                respuesta = busqueda.Delete();
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
