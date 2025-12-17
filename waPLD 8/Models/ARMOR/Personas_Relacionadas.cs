using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace waPLD.Models.ARMOR
{
    public partial class Personas_Relacionadas
    {
        [StringLength(20)]
        [DataMember]
        public string clienteid { get; set; }

        //[Required(ErrorMessage = "El valor :tiporelacion es requerido")]
        [StringLength(20)]
        [DataMember]
        public string? tiporelacion { get; set; }

        //[Required(ErrorMessage = "El valor :nombre es requerido")]
        [StringLength(100)]
        [DataMember]
        public string? nombre { get; set; }

        //[Required(ErrorMessage = "El valor :apellidopaterno es requerido")]
        [StringLength(30)]
        [DataMember]
        public string? apellidopaterno { get; set; }

        //[Required(ErrorMessage = "El valor :apellidomaterno es requerido")]
        [StringLength(30)]
        [DataMember]
        public string? apellidomaterno { get; set; }

        //[Required(ErrorMessage = "El valor :espersonafisica es requerido")]
        [DataMember]
        public int? espersonafisica { get; set; }

        //[Required(ErrorMessage = "El valor :sexo es requerido")]
        [StringLength(4)]
        [DataMember]
        public string? sexo { get; set; }


        //[StringLength(50)]
        [DataMember]
        public string? Pais { get ; set ; }

        //[Required(ErrorMessage = "El valor :estado es requerido")]
        [StringLength(50)]
        [DataMember]
        public string? estado { get; set; }

        //[Required(ErrorMessage = "El valor :rfc es requerido")]
        [StringLength(13)]
        [DataMember]
        public string? rfc { get; set; }

        //[Required(ErrorMessage = "El valor :curp es requerido")]
        [StringLength(18)]
        [DataMember]
        public string? curp { get; set; }

        //[Required(ErrorMessage = "El valor :municipio es requerido")]
        [StringLength(10)]
        [DataMember]
        public string? municipio { get; set; }

        //[Required(ErrorMessage = "El valor :colonia es requerido")]
        [StringLength(50)]
        [DataMember]
        public string? colonia { get; set; }

        //[Required(ErrorMessage = "El valor :calle es requerido")]
        [StringLength(50)]
        [DataMember]
        public string? calle { get; set; }

        //[Required(ErrorMessage = "El valor :numexterior es requerido")]
        [StringLength(20)]
        [DataMember]
        public string? numexterior { get; set; }

        //[Required(ErrorMessage = "El valor :numinterior es requerido")]
        [StringLength(20)]
        [DataMember]
        public string? numinterior { get; set; }

        //[Required(ErrorMessage = "El valor :cp es requerido")]
        [StringLength(50)]
        [DataMember]
        public string? cp { get; set; }

        //[Required(ErrorMessage = "El valor :ocupacion es requerido")]
        [StringLength(50)]
        [DataMember]
        public string? ocupacion { get; set; }

        //[Required(ErrorMessage = "El valor :paisnacimiento es requerido")]
        [StringLength(50)]
        [DataMember]
        public string? paisnacimiento { get; set; }

        //[Required(ErrorMessage = "El valor :giro_dsc es requerido")]
        [StringLength(255)]
        [DataMember]
        public string? giro_dsc { get; set; }

        //[Required(ErrorMessage = "El valor :inst_financiera_cve es requerido")]
        [StringLength(255)]
        [DataMember]
        public string? inst_financiera_cve { get; set; }

        //[Required(ErrorMessage = "El valor :giro_antiguedad es requerido")]
        [DataMember]
        public int? giro_antiguedad { get; set; }

        //[Required(ErrorMessage = "El valor :cobertura_tipo es requerido")]
        [StringLength(255)]
        [DataMember]
        public string? cobertura_tipo { get; set; }

        //[Required(ErrorMessage = "El valor :sucursal_rango es requerido")]
        [DataMember]
        public int? sucursal_rango { get; set; }

        //[Required(ErrorMessage = "El valor :empleado_rango es requerido")]
        [DataMember]
        public int? empleado_rango { get; set; }

        //[Required(ErrorMessage = "El valor :inst_financiera_tipo es requerido")]
        [StringLength(255)]
        [DataMember]
        public string? inst_financiera_tipo { get; set; }

        //[Required(ErrorMessage = "El valor :ingreso_mensual es requerido")]
        [DataMember]
        public int? ingreso_mensual { get; set; }

        //[Required(ErrorMessage = "El valor :ult_cierre_activo es requerido")]
        [DataMember]
        public int? ult_cierre_activo { get; set; }

        //[Required(ErrorMessage = "El valor :ult_cierre_pasivo es requerido")]
        [DataMember]
        public int? ult_cierre_pasivo { get; set; }

        //[Required(ErrorMessage = "El valor :ult_cierre_capital es requerido")]
        [DataMember]
        public int? ult_cierre_capital { get; set; }

        //[Required(ErrorMessage = "El valor :aportacionfideicomiso es requerido")]
        [StringLength(50)]
        [DataMember]
        public string? aportacionfideicomiso { get; set; }

        //[Required(ErrorMessage = "El valor :idpersonarelacionada es requerido")]
        [StringLength(20)]
        [DataMember]
        public string? idpersonarelacionada { get; set; }

        //[Required(ErrorMessage = "El valor :contrato es requerido")]
        [StringLength(50)]
        [DataMember]
        public string? contrato { get; set; }

        //[Required(ErrorMessage = "El valor :migrado es requerido")]
        [DataMember]
        public Int16? migrado { get; set; }

        //[Required(ErrorMessage = "El valor :nac_const_fecha es requerido")]
        [StringLength(8)]
        [DataMember]
        public string? nac_const_fecha { get; set; }

        //[Required(ErrorMessage = "El valor :estadocivil es requerido")]
        [DataMember]
        public int? estadocivil { get; set; }

        //[Required(ErrorMessage = "El valor :tipodomicilio es requerido")]
        [DataMember]
        public int? tipodomicilio { get; set; }

        //[Required(ErrorMessage = "El valor :tipovivienda es requerido")]
        [DataMember]
        public int? tipovivienda { get; set; }

        [DataMember]
        public string fechaemision { get; set; }

        //[Required(ErrorMessage = "El valor :proceso es requerido")]
        [DataMember]
        public int? proceso { get; set; }

        [DataMember]
        public int? Esprod { get; set; }
    }
}
