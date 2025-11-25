using System.ComponentModel;

namespace waPLD_8.Models.Bitacora
{
    public class Categoria
    {
        [DisplayName("No Categoria")]
        public int cCAT_Id { get; set; }
        [DisplayName("Descripcion")]
        public string cCAT_Descripcion { get; set; }

    }
}