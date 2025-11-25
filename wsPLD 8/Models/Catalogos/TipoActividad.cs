using System.ComponentModel;

namespace wsPLD_8.Models.Catalogos
{
    public class TipoActividad
    {
        [DisplayName("No TipoActividad")]
        public int cTAC_Id { get; set; }
        [DisplayName("Descripcion")]
        public string cTAC_Descripcion { get; set; }
    }
}
