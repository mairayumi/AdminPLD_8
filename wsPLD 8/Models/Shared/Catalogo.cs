using wsPLD_8.Models.Catalogos;
namespace wsPLD_8.Models.Shared
{
    public class Catalogo
    {
        public Catalogo()
        {
            catalogosTicketARMOR = new List<CatalogosTicketARMOR>();
        }

        public int cCAT_Id;
        public string? mensaje;
        public IList<CatalogosTicketARMOR> catalogosTicketARMOR;
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
            responsable = new HashSet<Responsable>() { };
        }

        public ICollection<Categoria> categoria { get; set; }
        public ICollection<Prioridad> prioridad { get; set; }
        public ICollection<TipoSolicitud> tipoSolicitud { get; set; }
        public ICollection<TipoActividad> tipoActividad { get; set; }
        public ICollection<EstadoSolicitud> estadoSolicitud { get; set; }
        public ICollection<EstadoActividad> estadoActividad { get; set; }
        public ICollection<Responsable> responsable { get; set; }

    }
}
