using System.ComponentModel;

namespace waPLD_8.Models.Bitacora
{
    public class Responsable
    {
        [DisplayName("No Responsable")]
        public int UsrId { get; set; }
        [DisplayName("Descripcion")]
        public string UserName { get; set; }
    }
}
