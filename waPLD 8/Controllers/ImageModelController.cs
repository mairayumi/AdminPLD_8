using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using waPLD_8.Models.Shared;
using waPLD_8.Extesion;
using waPLD_8.Models.Bitacora;

namespace waPLD_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageModelController : ControllerBase
    {
        // GET: api/<ImageModelController>
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                ImageModel imageModel = new ImageModel();
                respuesta = imageModel.Read();
            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = ex.Message;
                return BadRequest(respuesta);
            }
            return Ok(respuesta);
        }

        // GET api/<ImageModelController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                ImageModel imageModel = new ImageModel();
                respuesta = imageModel.Read();
            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = ex.Message;
                return BadRequest(respuesta);
            }
            return Ok(respuesta);
        }

        // POST api/<ImageModelController>
        [HttpPost]
        public IActionResult Post([FromBody] ImageModel value)
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

        // PUT api/<ImageModelController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ImageModel value)
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

        // DELETE api/<ImageModelController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                ImageModel imageModel = new ImageModel();
                respuesta = imageModel.Delete();
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