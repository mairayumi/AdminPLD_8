using System.ComponentModel;

namespace waPLD_8.Models.Catalogo.Usuario
{
    public class Direccion
    {
        public int Id { get; set; }

        [DisplayName("Calle")]
        public string cDIR_Calle { get; set; }
        [DisplayName("NoExt")]
        public string cDIR_NoExt { get; set; }
        [DisplayName("NoInt")]
        public string? cDIR_NoInt { get; set; }
        [DisplayName("Colonia")]
        public string? cDIR_Colonia { get; set; }
        [DisplayName("Ciudad")]
        public string? cDIR_Ciudad { get; set; }
        [DisplayName("Pais")]
        public string? cDIR_Pais { get; set; }
        [DisplayName("Estado")]
        public string? cDIR_Estado { get; set; }
        [DisplayName("CP")]
        public string? cDIR_CP { get; set; }

        public string? Titulo { get; set; }
        public string? SubTitulo { get; set; }
    }
}


