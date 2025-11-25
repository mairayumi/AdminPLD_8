using System.ComponentModel;

namespace wsPLD_8.Models.Catalogos
{
    public class EncOficio
    {
        [DisplayName("lOFD_Id")]
        public int lOFD_Id { get; set; }
        [DisplayName("lOFD_Año")]
        public int lOFD_Año { get; set; }
        [DisplayName("lOFD_Tipo")]
        public int lOFD_Tipo { get; set; }

        [DisplayName("PagAct")]
        public int PagAct { get; set; }

        [DisplayName("TotalPag")]
        public int TotalPag { get; set; }

        [DisplayName("Oficios")]
        public ICollection<Oficio> Oficios { get; set; }
    }
}
