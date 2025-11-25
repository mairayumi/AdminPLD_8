using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using waPLD_8.Extesion;
using waPLD_8.Models.Bitacora;
using waPLD_8.Models.Shared;


namespace waPLD_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TKAxActividadController : ControllerBase
    {
        // GET: api/<TKAxActividadController>
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta respuesta = new Respuesta();
            try
            {

            }
            catch (System.Exception)
            {

                throw;
            }
            return Ok(respuesta);
        }

        // GET api/<TKAxActividadController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {

            }
            catch (System.Exception)
            {

                throw;
            }
            return Ok(respuesta);
        }

        // POST api/<TKAxActividadController>
        [HttpPost]
        public IActionResult Post([FromBody] TKAxActividad value)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = value.Create();
            }
            catch (System.Exception)
            {

                throw;
            }
            return Ok(respuesta);
        }

        // PUT api/<TKAxActividadController>/5
        //[HttpPut("{id}")]
        [HttpPut]
        public IActionResult Put([FromBody] TKAxActividad value)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = value.Update();
            }
            catch (System.Exception)
            {
                throw;
            }
            return Ok(respuesta);
        }

        // DELETE api/<TKAxActividadController>/5
        [HttpDelete]
        public IActionResult Delete(int cTLS_Id, int cTKA_Id, int rTKA_Id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                TKAxActividad tKAxActividad = new TKAxActividad();
                tKAxActividad.cTLS_Id = cTLS_Id;
                tKAxActividad.cTKA_Id = cTKA_Id;
                tKAxActividad.rTKA_Id = rTKA_Id;
                respuesta = tKAxActividad.Delete();
            }
            catch (System.Exception)
            {
                throw;
            }
            return Ok(respuesta);
        }
    }
}