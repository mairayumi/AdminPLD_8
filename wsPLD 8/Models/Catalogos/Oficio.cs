using System.ComponentModel;

namespace wsPLD_8.Models.Catalogos
{
    public class Oficio
    {
        public Oficio()
        {
            Nombres = new List<DetOficio>();
        }

        [DisplayName("Oficio")]
        public string NombreOficio { get; set; }
        [DisplayName("Archivo")]
        public string Archivo { get; set; }
        [DisplayName("bgColor")]
        public string bgColor { get; set; }
        [DisplayName("Nombres")]
        
        public ICollection<DetOficio> Nombres { get; set; }
    }
}
