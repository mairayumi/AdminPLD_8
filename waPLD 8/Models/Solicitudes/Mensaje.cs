using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Security.Claims;

namespace waPLD.Models.Solicitudes
{
    public class Mensaje
    {
        public string sMensaje {  get; set; }
        public bool bExito { get; set; }
        public object oResultado { get; set; }
    }
}
