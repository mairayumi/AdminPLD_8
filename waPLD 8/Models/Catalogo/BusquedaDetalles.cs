using System.Collections.Generic;
using System.ComponentModel;

namespace waPLD.Models.Catalogo
{
    public class BusquedaDetalle
    {
        [DisplayName("No Busqueda")]
        public int cBSQ_Id { get; set; }
        [DisplayName("Renglon")]
        public int aBSD_Id { get; set; }
        [DisplayName("Id Cia")]
        public string cBSQ_IdCia { get; set; }
        [DisplayName("Persona")]
        public string aBSD_Nombre { get; set; }
        [DisplayName("Mensaje")]
        public string aBSD_message { get; set; }
        [DisplayName("Codigo")]
        public int aBSD_code { get; set; }
        [DisplayName("Persona en Lista negras")]
        public string aBSD_nombre_ln { get; set; }
        [DisplayName("Tipo de Lista Negra")]
        public string aBSD_lista { get; set; }
        [DisplayName("Comentario")]
        public string aBSD_comentarios { get; set; }        
    }
}
