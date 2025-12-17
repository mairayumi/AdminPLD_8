using System.Collections.Generic;

namespace waPLD.Models.Catalogo
{
    public class Busqueda
    {
        public Busqueda() {
            busquedaDetalles = new List<BusquedaDetalle>();
        }
        public int cBSQ_Id {  get; set; }
        public string cBSQ_Persona { get; set; }
        public int cBSQ_Fecha { get; set; }
        public int cBSQ_Status { get; set; }
        public int PagAct { get; set; }
        public int NoPagina { get; set; }
        public ICollection<BusquedaDetalle> busquedaDetalles { get; set; }
    }
}
