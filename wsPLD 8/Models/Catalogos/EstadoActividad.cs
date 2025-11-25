using System.ComponentModel;

namespace wsPLD_8.Models.Catalogos
{
    public class EstadoActividad
    {
        [DisplayName("No EstadoActividad")]
        public int cEAC_Id { get; set; }
        [DisplayName("Descripcion")]
        public string cEAC_Descripcion { get; set; }
        public string bgColor { get; set; }
    }
}
