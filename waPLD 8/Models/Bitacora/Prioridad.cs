using System.ComponentModel;

namespace waPLD_8.Models.Bitacora
{
    public class Prioridad
    {
        [DisplayName("No EstadoSolicitud")]
        public int cPRI_Id { get; set; }
        [DisplayName("Descripcion")]
        public string cPRI_Descripcion { get; set; }

    }
}