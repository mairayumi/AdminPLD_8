using waPLD.Models.Catalogo.Usuario;
using waPLD.Models.Shared;
using Microsoft.AspNetCore.Mvc;
using waPLD.Models.Bitacora;
using waPLD.Extesion;
using Microsoft.AspNetCore.Authorization;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace waPLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketARMORController : ControllerBase
    {
        //GET: api/<TicketARMORController>
        [HttpGet]
        public IActionResult Get(int cTLS_Id, int PagAct, string Filtro, string Periodo)
        {
            Respuesta respuesta = new Respuesta();
            try
            {                
                TicketARMOR ticketARMOR = new TicketARMOR();
                //ticketARMOR.NoPagina = PagAct;
                ticketARMOR.cTLS_Id = cTLS_Id;
                //ticketARMOR.PagAct = PagAct;
                //ticketARMOR.Filtro = Filtro;
                //ticketARMOR.Periodo = Periodo;
                respuesta = ticketARMOR.Read();
            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = ex.Message;
                return BadRequest(respuesta);
            }
            return Ok(respuesta);
        }

        // GET api/<TicketARMORController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                TicketARMOR ticketARMOR = new TicketARMOR();
                //ticketARMOR.NoPagina = 1;
                ticketARMOR.cTLS_Id = (id / 1000);
                ticketARMOR.cTKA_Id = (id % 1000);
                respuesta = ticketARMOR.Read();
            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = ex.Message;
                return BadRequest(respuesta);
            }
            return Ok(respuesta);
        }

        // POST api/<TicketARMORController>
        [HttpPost]
        public IActionResult Post([FromBody] TicketARMOR value)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = value.Create();
            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = ex.Message;
                return BadRequest(respuesta);
            }
            return Ok(respuesta);

        }

        // PUT api/<TicketARMORController>/5
        //[HttpPut("{id}")]
        [HttpPut]
        public IActionResult Put([FromBody] TicketARMOR value)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = value.Update();
            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = ex.Message;
                return BadRequest(respuesta);
            }
            return Ok(respuesta);
        }

        // DELETE api/<TicketARMORController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                TicketARMOR ticketARMOR = new TicketARMOR();
                ticketARMOR.cTLS_Id = (id / 1000);
                ticketARMOR.cTKA_Id = (id % 1000);
                respuesta = ticketARMOR.Delete();
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