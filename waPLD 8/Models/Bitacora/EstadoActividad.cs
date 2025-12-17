using System.ComponentModel;

namespace waPLD.Models.Bitacora
{
    public class EstadoActividad
    {
        [DisplayName("No EstadoActividad")]
        public int cEAC_Id { get; set; }
        [DisplayName("Descripcion")]
        public string cEAC_Descripcion { get; set; }
    }
}
