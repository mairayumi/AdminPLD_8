using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace waPLD.Models.Bitacora
{
    public class TicketARMOR
    {
        [DisplayName("Tipo Lista")]
        public int cTLS_Id { get; set; }

        [DisplayName("No Ticket")]
        public int cTKA_Id { get; set; }
        [DisplayName("Ticket Patria")]
        public int cTKA_TicketPatria { get; set; }
        [DisplayName("Ticket Salud")]
        public int cTKA_TicketSalud { get; set; }
        [DisplayName("Ticket Seguros")]
        public int cTKA_TicketSeguros { get; set; }
        [DisplayName("Fecha creacion")]
        public string cTKA_FechaCreado { get; set; }

        [DisplayName("IdCategoria")]
        public int cCAT_Id { get; set; }
        [DisplayName("Categoria")]
        public ICollection<Categoria> categoria { get; set; }
        [DisplayName("Idprioridad")]
        public int cPRI_Id { get; set; }
        [DisplayName("Prioridad")]
        public ICollection<Prioridad> prioridad { get; set; }

        [DisplayName("Asunto")]
        [Required(ErrorMessage = "El Asunto es obligatorio")]
        public string? cTKA_Asunto { get; set; }
        [DisplayName("Id Tipo de Solicitud")]
        public int cTIS_Id { get; set; }

        [DisplayName("Tipo de Solicitud")]
        public ICollection<TipoSolicitud> tipoSolicitud { get; set; }
        [DisplayName("Id Estado de Solicitud")]
        public int cESO_Id { get; set; }
        [DisplayName("Estado de Solicitud")]
        public ICollection<EstadoSolicitud> estadoSolicitud { get; set; }
        [DisplayName("Estatus de Spot")]
        [Required(ErrorMessage = "El estatus de SPOT es obligatorio")]
        public string? cTKA_EstatusSpot { get; set; }
        
        [DisplayName("Actividades de GPV")]
        public ICollection<TKAxActividad> actividades { get; set; }

        [DisplayName("Fecha de Solucion")]
        public string? cTKA_FechaSolucion { get; set; }
        [DisplayName("Fecha de Sol. Real")]
        public string? cTKA_FechaSolucionReal { get; set; }
        [DisplayName("Fecha de Pruebas")]
        public string? cTKA_FechaPruebas { get; set; }
        [DisplayName("Fecha de Despliegue")]
        public string? cTKA_FechaDespliegue { get; set; }
        [DisplayName("Fecha de Prueb. Prod")]

        public string? cTKA_FechaPruebasProd { get; set; }
        [DisplayName("Fecha de Seguimiento")]
        public string? cTKA_FechaSeguimiento { get; set; }

        [DisplayName("Seccion de la Sub-Aplicacion")]

        public string? cTKA_SeccionSubAplicacion { get; set; }
        [DisplayName("Usuario Afectado")]
        [Required(ErrorMessage = "El Usuario afectado es obligatorio")]
        public string? cTKA_UsuarioAfectado { get; set; }
        [DisplayName("Observaciones")]
        public string? cTKA_Observaciones { get; set; }

        [DisplayName("Dependencia")]
        public int cTKA_DependeDe { get; set; }
        public string? Accion { get; set; }
        public int NoPagina { get; set; }
    }
}