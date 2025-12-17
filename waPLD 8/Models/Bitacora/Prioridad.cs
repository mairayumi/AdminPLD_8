using System.ComponentModel;

namespace waPLD.Models.Bitacora
{
    public class Prioridad
    {
        [DisplayName("No EstadoSolicitud")]
        public int cPRI_Id {  get; set; }
        [DisplayName("Descripcion")]
        public string cPRI_Descripcion {  get; set; }

    }
}
