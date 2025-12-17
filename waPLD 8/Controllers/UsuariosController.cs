using Microsoft.AspNetCore.Mvc;
using System;
using waPLD.Models.Shared;
using waPLD.Models.Catalogo.Usuario;
using waPLD.Extesion;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace waPLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                Usuarios usuarios= new Usuarios();
                usuarios.UsrId = id;
                respuesta = usuarios.Read();
            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = ex.Message;
                return BadRequest(respuesta);
            }
            return Ok(respuesta);
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public IActionResult Post([FromBody] Usuarios value)
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

        // PUT api/<UsuariosController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Usuarios value)
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

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                Usuarios usuarios = new Usuarios();
                usuarios.UsrId = id;
                respuesta = usuarios.Delete();
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
