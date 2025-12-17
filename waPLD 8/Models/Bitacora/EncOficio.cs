using System.Collections.Generic;
using System.ComponentModel;

namespace waPLD.Models.Bitacora
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
    }
}
