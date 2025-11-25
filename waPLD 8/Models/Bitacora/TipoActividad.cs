using System.ComponentModel;

namespace waPLD_8.Models.Bitacora
{
    public class TipoActividad
    {
        [DisplayName("No TipoActividad")]
        public int cTAC_Id { get; set; }
        [DisplayName("Descripcion")]
        public string cTAC_Descripcion { get; set; }
    }
}