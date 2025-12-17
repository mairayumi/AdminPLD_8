namespace waPLD.Models.Solicitudes
{
    public class ProcesandoSolicitud
    {
        public int SolicitudId { get; set; }
        public ServerLF serverLF {  get; set; }
        public Solicitud solicitud {  get; set; }
        public MetaDataLF metaDataLF { get; set; }
    }
}
