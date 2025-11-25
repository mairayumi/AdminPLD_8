using waPLD_8.Models.ARMOR;

namespace waPLD_8.Models.Bitacora
{
    public class DatosGenerales
    {
        public int Id { get; set; }
        public string ClienteId { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        string ApellidoMaterno { get; set; }
        public string fecharegistro { get; set; }
        public string Contrato { get; set; }
        public string AgenteNombre { get; set; }
        public string AgenteApellidoPaterno { get; set; }
        public string AgenteApellidoMaterno { get; set; }
        public IList<Operacion> operacions { get; set; }
    }
}
