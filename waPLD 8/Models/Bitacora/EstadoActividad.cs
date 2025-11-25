using System.ComponentModel;

namespace waPLD_8.Models.Bitacora
{
    public class EstadoActividad
    {
        [DisplayName("No EstadoActividad")]
        public int cEAC_Id { get; set; }
        [DisplayName("Descripcion")]
        public string cEAC_Descripcion { get; set; }
    }
}
