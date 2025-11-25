using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace waPLD_8.Models.ARMOR
{
    public partial class Datos_Domicilios
    {
        [StringLength(20)]
        [DataMember]
        public string clienteid { get; set; }

        //[Required(ErrorMessage = "El valor :tipodomicilio es requerido")]
        [DataMember]
        public int? tipodomicilio { get; set; }

        //[Required(ErrorMessage = "El valor :tipovivienda es requerido")]
        [DataMember]
        public int? tipovivienda { get; set; }

        //[Required(ErrorMessage = "El valor :pais es requerido")]
        [StringLength(10)]
        [DataMember]
        public string? pais { get; set; }

        //[Required(ErrorMessage = "El valor :estado es requerido")]
        [StringLength(10)]
        [DataMember]
        public string? estado { get; set; }

        //[Required(ErrorMessage = "El valor :municipio es requerido")]
        [StringLength(10)]
        [DataMember]
        public string? municipio { get; set; }

        //[Required(ErrorMessage = "El valor :colonia es requerido")]
        [StringLength(250)]
        [DataMember]
        public string? colonia { get; set; }

        //[Required(ErrorMessage = "El valor :calle es requerido")]
        [StringLength(250)]
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
