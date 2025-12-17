using Microsoft.EntityFrameworkCore.Migrations.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace waPLD.Models.ARMOR
{
    public partial class Persona_Documento
    {
        [StringLength(20)]
        [DataMember]
        public string clienteid { get; set; }

        //[Required(ErrorMessage = "El valor :documento_tipo es requerido")]
        [DataMember]
        public int? documento_tipo { get; set; }

        //[Required(ErrorMessage = "El valor :documentacion_tipo es requerido")]
        [DataMember]
        public int? documentacion_tipo { get; set; }

        //[Required(ErrorMessage = "El valor :folio es requerido")]
        [StringLength(255)]
        [DataMember]
        public string? folio { get; set; }

        //[Required(ErrorMessage = "El valor :emision es requerido")]
        [StringLength(8)]
        [DataMember]
        public string? emision { get; set; }

        //[Required(ErrorMessage = "El valor :vigencia es requerido")]
        [StringLength(8)]
        [DataMember]
        public string? vigencia { get; set; }

        //[Required(ErrorMessage = "El valor :archivo es requerido")]
        [StringLength(255)]
        [DataMember]
        public string? archivo { get; set; }

        //[Required(ErrorMessage = "El valor :tipo_persona es requerido")]
        [DataMember]
        public int? tipo_persona { get; set; }

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
