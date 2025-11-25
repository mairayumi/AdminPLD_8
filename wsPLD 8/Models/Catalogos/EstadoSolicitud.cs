using System.ComponentModel;

namespace wsPLD_8.Models.Catalogos
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
