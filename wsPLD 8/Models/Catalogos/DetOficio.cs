using System.ComponentModel;

namespace wsPLD_8.Models.Catalogos
{
    public class DetOficio
    {
        public string Nombre { get; set; }
        [DisplayName("bgColor")]
        public string bgColor { get; set; }
    }
}
