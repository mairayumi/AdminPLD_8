using System.ComponentModel;

namespace waPLD.Models.Bitacora
{
    public class TipoSolicitud
    {
        [DisplayName("No TipoSolicitud")]
        public int cTIS_Id {  get; set; }
        [DisplayName("Descripcion")]
        public string cTIS_Descripcion {  get; set; }

    }
}
