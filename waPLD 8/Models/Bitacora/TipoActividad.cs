using System.ComponentModel;

namespace waPLD.Models.Bitacora
{
    public class TipoActividad
    {
        [DisplayName("No TipoActividad")]
        public int cTAC_Id { get; set; }
        [DisplayName("Descripcion")]
        public string cTAC_Descripcion { get; set; }
    }
}
