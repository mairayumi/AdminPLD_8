using System.ComponentModel;

namespace wsPLD_8.Models.Catalogos
{
    public class Responsable
    {
        [DisplayName("No Responsable")]
        public int UsrId { get; set; }
        [DisplayName("Descripcion")]
        public string UserName { get; set; }
    }
}
