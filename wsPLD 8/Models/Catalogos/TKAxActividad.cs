using System;
using System.ComponentModel;
using wsPLD_8.Models.Catalogos;

namespace wsPLD_8.Models.Catalogos
{
    public class TKAxActividad
    {
        [DisplayName("Tipo Lista")]
        public int cTLS_Id { get; set; }

        [DisplayName("No Ticket")]
        public int cTKA_Id { get; set; }
        [DisplayName("Consecutivo")]
        public int rTKA_Id { get; set; }
        [DisplayName("Actividad")]
        public string rTKA_Actividad { get; set; }
        [DisplayName("Fecha de Seguimiento")]
        public string rTKA_FechaSeguimiento { get; set; }

        [DisplayName("Id Tipo de Actividad")]
        public int cTAC_Id { get; set; }

        [DisplayName("Tipo")]
        public ICollection<TipoActividad> tipoActividad { get; set; }
        [DisplayName("Id Estado de la Actividad")]
        public int cEAC_Id { get; set; }
        [DisplayName("Estatus")]
        public ICollection<EstadoActividad> estadoActividad { get; set; }
        [DisplayName("Id del Responsable")]
        public int UsrId { get; set; }
        [DisplayName("Responsable")]
        public ICollection<Responsable> responsable { get; set; }

    }
}
