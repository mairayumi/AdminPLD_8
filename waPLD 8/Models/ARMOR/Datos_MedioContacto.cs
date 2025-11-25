using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace waPLD_8.Models.ARMOR
{
    public partial class Datos_MedioContacto
    {
        [StringLength(20)]
        [DataMember]
        public string idpersona { get; set; }

        //[Required(ErrorMessage = "El valor :idmediocontacto es requerido")]
        [DataMember]
        public int? idmediocontacto { get; set; }

        [Required(ErrorMessage = "El valor :valor es requerido")]
        [StringLength(250)]
        [DataMember]
        public string valor { get; set; }

        //[Required(ErrorMessage = "El valor :tipo_persona es requerido")]
        [StringLength(50)]
        [DataMember]
        public string? tipo_persona { get; set; }

        //[Required(ErrorMessage = "El valor :contrato es requerido")]
        [StringLength(50)]
        [DataMember]
        public string? contrato { get; set; }

        //[Required(ErrorMessage = "El valor :migrado es requerido")]
        [DataMember]
        public Int16? migrado { get; set; }

        [DataMember]
        public string fechaemision { get; set; }

        //[Required(ErrorMessage = "El valor :proceso es requerido")]
        [DataMember]
        public int? proceso { get; set; }

        [DataMember]
        public int? Esprod { get; set; }
    }
}
