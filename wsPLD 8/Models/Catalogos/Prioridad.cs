using System.ComponentModel;

namespace wsPLD_8.Models.Catalogos
{
    public class Prioridad
    {
        [DisplayName("No EstadoSolicitud")]
        public int cPRI_Id { get; set; }
        [DisplayName("Descripcion")]
        public string cPRI_Descripcion { get; set; }

    }
}
