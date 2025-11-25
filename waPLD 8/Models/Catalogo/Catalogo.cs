using System.Collections.Generic;
using waPLD_8.Models.Bitacora;
namespace waPLD_8.Models.Catalogo
{
    public class Catalogo
    {
        public int cCAT_Id;
        public string? mensaje;
        public CatalogosTicketARMOR catalogosTicketARMOR;
    }

    public class CatalogosTicketARMOR
    {
        public CatalogosTicketARMOR()
        {
            categoria = new HashSet<Categoria>() { };//new HashSet<Categoria>() { };
            prioridad = new HashSet<Prioridad>() { };
            tipoSolicitud = new HashSet<TipoSolicitud>() { };
            tipoActividad = new HashSet<TipoActividad>() { };
            estadoSolicitud = new HashSet<EstadoSolicitud>() { };
            estadoActividad = new HashSet<EstadoActividad>() { };
        }

        public ICollection<Categoria> categoria { get; set; }
        public ICollection<Prioridad> prioridad { get; set; }
        public ICollection<TipoSolicitud> tipoSolicitud { get; set; }
        public ICollection<TipoActividad> tipoActividad { get; set; }
        public ICollection<EstadoSolicitud> estadoSolicitud { get; set; }
        public ICollection<EstadoActividad> estadoActividad { get; set; }
    }

}
