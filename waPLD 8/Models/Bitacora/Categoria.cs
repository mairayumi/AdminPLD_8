using System.ComponentModel;

namespace waPLD.Models.Bitacora
{
    public class Categoria
    {
        [DisplayName("No Categoria")]
        public int cCAT_Id {  get; set; }
        [DisplayName("Descripcion")]
        public string cCAT_Descripcion {  get; set; }

    }
}
