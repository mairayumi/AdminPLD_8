using System.ComponentModel;

namespace wsPLD_8.Models.Catalogos
{
    public class TipoLista
    {
        public TipoLista()
        {
            ticketARMOR = new HashSet<TicketARMOR>();
        }

        [DisplayName("Tipo de Lista")]
        public int cTLS_Id { get; set; }
        [DisplayName("Nombre")]
        public string cTLS_Nombre { get; set; }
        [DisplayName("Ticket de ARMOR")]
        public ICollection<TicketARMOR> ticketARMOR { get; set; }
        //public string? Filtro { get; set; }
        //public string? Periodo { get; set; }
        //public int PagAct { get; set; }
    }
}
