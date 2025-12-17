using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace waPLD.Models.ARMOR
{
    public partial class Datos_Generales
    {
        //[Required(ErrorMessage = "El valor :token es requerido")]
        [StringLength(50)]
        [DataMember]
        public string? token { get; set; }

        //[Required(ErrorMessage = "El valor :origen es requerido")]
        [StringLength(20)]
        [DataMember]
        public string? origen { get; set; }

        //[Required(ErrorMessage = "El valor :procesono es requerido")]
        [DataMember]
        public int? procesono { get; set; }

        [DataMember]
        public string fecharegistro { get; set; }

        //[Required(ErrorMessage = "El valor :horaregistro es requerido")]
        [StringLength(18)]
        [DataMember]
        public string? horaregistro { get; set; }

        //[Required(ErrorMessage = "El valor :clienteid es requerido")]
        [StringLength(20)]
        [DataMember]
        public string? clienteid { get; set; }

        //[Required(ErrorMessage = "El valor :nombre es requerido")]
        [StringLength(255)]
        [DataMember]
        public string? nombre { get; set; }

        //[Required(ErrorMessage = "El valor :apellidopaterno es requerido")]
        [StringLength(255)]
        [DataMember]
        public string? apellidopaterno { get; set; }

        //[Required(ErrorMessage = "El valor :apellidomaterno es requerido")]
        [StringLength(255)]
        [DataMember]
        public string? apellidomaterno { get; set; }

        //[Required(ErrorMessage = "El valor :denominacioninstitucion es requerido")]
        [StringLength(100)]
        [DataMember]
        public string? denominacioninstitucion { get; set; }

        //[Required(ErrorMessage = "El valor :clave_compania es requerido")]
        [StringLength(255)]
        [DataMember]
        public string? clave_compania { get; set; }

        //[Required(ErrorMessage = "El valor :finalidadfideicomiso es requerido")]
        [StringLength(255)]
        [DataMember]
        public string? finalidadfideicomiso { get; set; }

        //[Required(ErrorMessage = "El valor :patriminiofideocomitido es requerido")]
        [DataMember]
        public int? patriminiofideocomitido { get; set; }

        //[Required(ErrorMessage = "El valor :personafisical es requerido")]
        [DataMember]
        public int? personafisical { get; set; }

        //[Required(ErrorMessage = "El valor :estadocivil es requerido")]
        [DataMember]
        public int? estadocivil { get; set; }

        //[Required(ErrorMessage = "El valor :sexo es requerido")]
        [DataMember]
        public int? sexo { get; set; }

        //[Required(ErrorMessage = "El valor :paisnacimiento es requerido")]
        [StringLength(10)]
        [DataMember]
        public string? paisnacimiento { get; set; }

        //[Required(ErrorMessage = "El valor :estadonacimiento es requerido")]
        [StringLength(10)]
        [DataMember]
        public string? estadonacimiento { get; set; }

        //[Required(ErrorMessage = "El valor :rfc es requerido")]
        [StringLength(13)]
        [DataMember]
        public string? rfc { get; set; }

        //[Required(ErrorMessage = "El valor :curp es requerido")]
        [StringLength(18)]
        [DataMember]
        public string? curp { get; set; }

        //[Required(ErrorMessage = "El valor :nac_const_fecha es requerido")]
        [StringLength(8)]
        [DataMember]
        public string? nac_const_fecha { get; set; }

        [StringLength(50)]
        [DataMember]
        public string contrato { get; set; }

        //[Required(ErrorMessage = "El valor :montototal es requerido")]
        [DataMember]
        public double? montototal { get; set; }

        //[Required(ErrorMessage = "El valor :prima es requerido")]
        [DataMember]
        public double? prima { get; set; }

        //[Required(ErrorMessage = "El valor :producto es requerido")]
        [DataMember]
        public int? producto { get; set; }

        //[Required(ErrorMessage = "El valor :periodicidad es requerido")]
        [StringLength(100)]
        [DataMember]
        public string? periodicidad { get; set; }

        //[Required(ErrorMessage = "El valor :id_instrumento es requerido")]
        [StringLength(10)]
        [DataMember]
        public string? id_instrumento { get; set; }

        //[Required(ErrorMessage = "El valor :finalidadprestamo es requerido")]
        [StringLength(255)]
        [DataMember]
        public string? finalidadprestamo { get; set; }

        //[Required(ErrorMessage = "El valor :vigenciainicio es requerido")]
        [StringLength(8)]
        [DataMember]
        public string? vigenciainicio { get; set; }

        //[Required(ErrorMessage = "El valor :vigenciafin es requerido")]
        [StringLength(8)]
        [DataMember]
        public string? vigenciafin { get; set; }

        //[Required(ErrorMessage = "El valor :nivelriesgo es requerido")]
        [DataMember]
        public int? nivelriesgo { get; set; }

        //[Required(ErrorMessage = "El valor :ocupacion es requerido")]
        [StringLength(50)]
        [DataMember]
        public string? ocupacion { get; set; }

        //[Required(ErrorMessage = "El valor :giro_desc es requerido")]
        [StringLength(255)]
        [DataMember]
        public string? giro_desc { get; set; }

        //[Required(ErrorMessage = "El valor :inst_financiera_cve es requerido")]
        [StringLength(255)]
        [DataMember]
        public string? inst_financiera_cve { get; set; }

        //[Required(ErrorMessage = "El valor :giro_antiguedad es requerido")]
        [DataMember]
        public int? giro_antiguedad { get; set; }

        //[Required(ErrorMessage = "El valor :cobertura_tipo es requerido")]
        [DataMember]
        public int? cobertura_tipo { get; set; }

        //[Required(ErrorMessage = "El valor :sucursal_rango es requerido")]
        [DataMember]
        public int? sucursal_rango { get; set; }

        //[Required(ErrorMessage = "El valor :empleado_rango es requerido")]
        [DataMember]
        public int? empleado_rango { get; set; }

        //[Required(ErrorMessage = "El valor :inst_financiera_tipo es requerido")]
        [StringLength(20)]
        [DataMember]
        public string? inst_financiera_tipo { get; set; }

        //[Required(ErrorMessage = "El valor :ingreso_mensual es requerido")]
        [DataMember]
        public double? ingreso_mensual { get; set; }

        //[Required(ErrorMessage = "El valor :ult_cierre_activo es requerido")]
        [DataMember]
        public int? ult_cierre_activo { get; set; }

        //[Required(ErrorMessage = "El valor :ult_cierre_pasivo es requerido")]
        [DataMember]
        public int? ult_cierre_pasivo { get; set; }

        //[Required(ErrorMessage = "El valor :ult_cierre_capital es requerido")]
        [DataMember]
        public int? ult_cierre_capital { get; set; }

        //[Required(ErrorMessage = "El valor :origenrecurso es requerido")]
        [DataMember]
        public int? origenrecurso { get; set; }

        //[Required(ErrorMessage = "El valor :fuenterecurso es requerido")]
        [DataMember]
        public int? fuenterecurso { get; set; }

        //[Required(ErrorMessage = "El valor :idsucursal es requerido")]
        [DataMember]
        public int? idsucursal { get; set; }

        //[Required(ErrorMessage = "El valor :claveempleado es requerido")]
        [StringLength(50)]
        [DataMember]
        public string? claveempleado { get; set; }

        //[Required(ErrorMessage = "El valor :estatus es requerido")]
        [StringLength(9)]
        [DataMember]
        public string? estatus { get; set; }

        //[Required(ErrorMessage = "El valor :migrado es requerido")]
        [DataMember]
        public Int16? migrado { get; set; }

        //[Required(ErrorMessage = "El valor :perfil_declara_tipo_id es requerido")]
        [DataMember]
        public int? perfil_declara_tipo_id { get; set; }

        //[Required(ErrorMessage = "El valor :foliomercantil es requerido")]
        [StringLength(50)]
        [DataMember]
        public string? foliomercantil { get; set; }

        //[Required(ErrorMessage = "El valor :nombrecotejo es requerido")]
        [StringLength(120)]
        [DataMember]
        public string? nombrecotejo { get; set; }

        //[Required(ErrorMessage = "El valor :numero_aportaciones es requerido")]
        [DataMember]
        public int? numero_aportaciones { get; set; }

        //[Required(ErrorMessage = "El valor :monto_aportaciones es requerido")]
        [DataMember]
        public double? monto_aportaciones { get; set; }

        //[Required(ErrorMessage = "El valor :numero_retiros es requerido")]
        [DataMember]
        public int? numero_retiros { get; set; }

        //[Required(ErrorMessage = "El valor :monto_retiros es requerido")]
        [DataMember]
        public double? monto_retiros { get; set; }

        //[Required(ErrorMessage = "El valor :montomaxmensual es requerido")]
        [DataMember]
        public double? montomaxmensual { get; set; }

        //[Required(ErrorMessage = "El valor :idmontorango es requerido")]
        [DataMember]
        public int? idmontorango { get; set; }

        //[Required(ErrorMessage = "El valor :idtransaccionrango es requerido")]
        [DataMember]
        public int? idtransaccionrango { get; set; }

        //[Required(ErrorMessage = "El valor :frecuencia es requerido")]
        [DataMember]
        public Int16? frecuencia { get; set; }

        //[Required(ErrorMessage = "El valor :iddivisa es requerido")]
        [DataMember]
        public int? iddivisa { get; set; }

        //[Required(ErrorMessage = "El valor :otrosrec es requerido")]
        [StringLength(200)]
        [DataMember]
        public string? otrosrec { get; set; }

        //[Required(ErrorMessage = "El valor :destinorecursos es requerido")]
        [DataMember]
        public int? destinorecursos { get; set; }

        //[Required(ErrorMessage = "El valor :cve_cli_nit es requerido")]
        [StringLength(30)]
        [DataMember]
        public string? cve_cli_nit { get; set; }

        //[Required(ErrorMessage = "El valor :cve_pais_nit es requerido")]
        [StringLength(30)]
        [DataMember]
        public string? cve_pais_nit { get; set; }

        //[Required(ErrorMessage = "El valor :cve_indicador es requerido")]
        [StringLength(30)]
        [DataMember]
        public string? cve_indicador { get; set; }

        //[Required(ErrorMessage = "El valor :reg_cnbv_condusef es requerido")]
        [StringLength(30)]
        [DataMember]
        public string? reg_cnbv_condusef { get; set; }

        //[Required(ErrorMessage = "El valor :id_registro es requerido")]
        [StringLength(30)]
        [DataMember]
        public string? id_registro { get; set; }

        //[Required(ErrorMessage = "El valor :ent_fed_nac es requerido")]
        [StringLength(30)]
        [DataMember]
        public string? ent_fed_nac { get; set; }

        [DataMember]
        public int? Esprod { get; set; }

    }
}