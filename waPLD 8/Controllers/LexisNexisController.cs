using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using waPLD.Models.LexisNexis;
using waPLD.Models.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace waPLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LexisNexisController : ControllerBase
    {
        // POST api/<UsuariosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LexisNexis lexisnexis)
        {
            Respuesta resultado = new Respuesta();

            // Path to file on SFTP server
            string pathRemoteFile = Path.Combine(lexisnexis.remotePath, lexisnexis.File + ".zip");
            // Path where the file should be saved once downloaded (locally)
            string pathLocalFile = Path.Combine(lexisnexis.LocalPath, lexisnexis.File + ".zip");

            ConnectionInfo connectinfo = new ConnectionInfo(
                                                lexisnexis.hostname,
                                                int.Parse(lexisnexis.port),
                                                lexisnexis.username,
                                                new PasswordAuthenticationMethod(lexisnexis.username, lexisnexis.password)
                                            );

            using (Renci.SshNet.SftpClient sftp = new Renci.SshNet.SftpClient(connectinfo))
            {
                try
                {
                    if (!System.IO.File.Exists(pathLocalFile))
                    {
                        sftp.Connect();
                        using (Stream fileStream = System.IO.File.OpenWrite(pathLocalFile))
                        {
                            sftp.DownloadFile(pathRemoteFile, fileStream);
                        }
                        sftp.Disconnect();

                        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                        using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(pathLocalFile))
                        {
                            zip.Password = lexisnexis.passwordZip;
                            zip.ExtractAll(lexisnexis.LocalPath + lexisnexis.File, Ionic.Zip.ExtractExistingFileAction.DoNotOverwrite);
                        }
                        resultado.Data = pathLocalFile;
                    }
                    else
                    {
                        resultado.exito = 0;
                        resultado.mensaje = "El archivo ya existe.";
                        Console.Write(resultado);
                        return BadRequest(resultado);
                    }
                }
                catch (Exception err)
                {
                    resultado.exito = 0;
                    resultado.mensaje = err.Message;
                    sftp.Disconnect();
                    if (!lexisnexis.hostname.Equals("209.243.49.204"))
                    {
                        lexisnexis.hostname = "209.243.49.204";
                        /*resultado = Post(lexisnexis);*/
                    }
                    else
                    {
                        resultado.exito = 0;
                        resultado.mensaje = err.Message;
                        Console.Write(resultado);
                        return BadRequest(resultado);
                    }
                }
                return Ok(resultado);
            }

        }
    }
}
