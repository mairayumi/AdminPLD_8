using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace waPLD.Models.Catalogo.Usuario
{
    public class Usuario
    {
        public Usuario()
        {
            Domicilios = new List<Direccion> { new Direccion(), new Direccion() };
            MediosCont = new List<MedioCont> { new MedioCont(), new MedioCont() };
        }
        public string? cUSR_Usr { get; set; }
        public string? cUSR_Password { get; set; }
        public string? cUSR_Dominio { get; set; }
        public string? cUSR_PCName { get; set; }
        public string? cUSR_servidorWeb { get; set; }
        public string? cUSR_sourceBD { get; set; }
        public string? cUSR_catalogBD { get; set; }
        public string? cUSR_userBD { get; set; }
        public string? cUSR_passwordBD { get; set; }
        public string? cUSR_Token { get; set; }
        

        [DisplayName("Nombre")]
        public string cUSR_Nombre { get; set; }
        public string? cUSR_ApePaterno { get; set; }
        public string? cUSR_ApeMaterno { get; set; }
        [DisplayName("Fec Nac.")]
        public DateTime? cUSR_FecNacimiento { get; set; }
        [DisplayName("Fec Alta")]
        public DateTime cUSR_FecAlta { get; set; }
        [DisplayName("CURP")]
        public string? cUSR_CURP { get; set; }
        [DisplayName("RFC")]
        public string cUSR_RFC { get; set; }
        [DisplayName("Imagen")]
        public string? cUSR_Fotografia { get; set; }

        public int edad
        {
            get
            {
                DateTime FecNacimiento = (DateTime)cUSR_FecNacimiento.GetValueOrDefault(DateTime.Now);
                return DateTime.Now.Subtract(FecNacimiento).Days;
            }
        }

        public string? Titulo { get; set; }
        public string? SubTitulo { get; set; }
        public List<Direccion> Domicilios { get; set; }
        public List<MedioCont> MediosCont { get; set; }

    }
}
