using System.Collections.Generic;
using System.Reflection.Metadata;

namespace waPLD.Models.Solicitudes
{
    public class Solicitud
    {
        public int SolicitudId { get; set; }
        public IList<DocumenLF> DocumentLFs { get; set; }
        public MetaDataLF metaDataLF { get; set; }
    }
}
