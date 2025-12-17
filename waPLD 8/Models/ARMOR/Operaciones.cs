using Microsoft.EntityFrameworkCore.Migrations.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace waPLD.Models.ARMOR
{
    public partial class Operaciones
    {
        //[Required(ErrorMessage = "El valor :identificadoroperacion es requerido")]
        [StringLength(50)]
        [DataMember]
        public string? identificadoroperacion { get; set; }

        //[Required(ErrorMessage = "El valor :rfc es requerido")]
        [StringLength(13)]
        [DataMember]
        public string? rfc { get; set; }

        [StringLength(50)]
        [DataMember]
        public string numerocontrato { get; set; }

        //[Required(ErrorMessage = "El valor :tipotransaccion es requerido")]
        [StringLength(20)]
        [DataMember]
        public string? tipotransaccion { get; set; }

        //[Required(ErrorMessage = "El valor :sucursal es requerido")]
        [StringLength(50)]
        [DataMember]
        public string? sucursal { get; set; }

        //[Required(ErrorMessage = "El valor :fechacaptura es requerido")]
        [StringLength(10)]
        [DataMember]
        public string? fechacaptura { get; set; }

        //[Required(ErrorMessage = "El valor :fechaoperacion es requerido")]
        [StringLength(10)]
        [DataMember]
        public string? fechaoperacion { get; set; }

        //[Required(ErrorMessage = "El valor :fechaliquidacion es requerido")]
        [StringLength(10)]
        [DataMember]
        public string? fechaliquidacion { get; set; }

        //[Required(ErrorMessage = "El valor :periodicidad es requerido")]
        [StringLength(10)]
        [DataMember]
        public string? periodicidad { get; set; }

        //[Required(ErrorMessage = "El valor :producto es requerido")]
        [DataMember]
        public int? producto { get; set; }

        //[Required(ErrorMessage = "El valor :divisa es requerido")]
        [DataMember]
        public string? divisa { get; set; }

        //[Required(ErrorMessage = "El valor :importe es requerido")]
        [DataMember]
        public double? importe { get; set; }

        //[Required(ErrorMessage = "El valor :instrumento es requerido")]
        [StringLength(20)]
        [DataMember]
        public string? instrumento { get; set; }

        //[Required(ErrorMessage = "El valor :esultimopago es requerido")]
        [DataMember]
        public string? esultimopago { get; set; }

        //[Required(ErrorMessage = "El valor :escancelado es requerido")]
        [DataMember]
        public string? escancelado { get; set; }

        //[Required(ErrorMessage = "El valor :migrado es requerido")]
        [DataMember]
        public Int16? migrado { get; set; }

        //[Required(ErrorMessage = "El valor :ins_bancaria es requerido")]
        [DataMember]
        public int? ins_bancaria { get; set; }

        [DataMember]
        public string fechaemision { get; set; }

        //[Required(ErrorMessage = "El valor :proceso es requerido")]
        [DataMember]
        public int? proceso { get; set; }

        //[Required(ErrorMessage = "El valor :clienteid es requerido")]
        [StringLength(20)]
        [DataMember]
        public string? clienteid { get; set; }

        [DataMember]
        public int? Esprod { get; set; }
    }
}
