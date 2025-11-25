using System.ComponentModel;

namespace waPLD_8.Models.Bitacora
{
    public class EstadoSolicitud
    {
        [DisplayName("No EstadoSolicitud")]
        public int cESO_Id { get; set; }
        [DisplayName("Descripcion")]
        public string cESO_Descripcion { get; set; }
        public string bgColor { get; set; }

    }
}