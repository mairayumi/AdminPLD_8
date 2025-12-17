using Microsoft.AspNetCore.Mvc;
using System;
using waPLD.Extesion;
using waPLD.Models.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace waPLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HTMLEmailController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(
                string Mail_Para
                , string Mail_CC
                , string Asunto
                , string Titulo
                , string SubTitulo
                , string DirigidoA
                , string Body
                , string Link
                , string adjunto
                , string TextoLink)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                HTMLEmail htmlEmail = new HTMLEmail();
                htmlEmail.Mail_Para = Mail_Para;
                htmlEmail.Mail_CC = Mail_CC;
                htmlEmail.Asunto = Asunto;
                htmlEmail.Titulo = Titulo;
                htmlEmail.SubTitulo = SubTitulo;
                htmlEmail.DirigidoA = DirigidoA;
                htmlEmail.Body = Body;
                htmlEmail.Link = Link;
                htmlEmail.adjunto = adjunto;
                htmlEmail.TextoLink = TextoLink;

                respuesta = htmlEmail.Read();
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