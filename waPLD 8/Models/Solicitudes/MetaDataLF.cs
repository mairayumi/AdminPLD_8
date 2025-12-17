namespace waPLD.Models.Solicitudes
{
    public class MetaDataLF
    {
        public int SolicitudId { get; set; }
        public int EmpleadoId { get; set; }
        public string k_Empresa { get; set; }
        public string K_Usuario { get; set; }
        public string K_Area { get; set; }
        public string K_Depto { get; set; }
        public string K_Carpeta { get; set; }
        public string K_Usuario_Correo { get; set; }
        public string PathCarpeta { get; set; }
    
        public string U_Tipo_Reaseguro {  get; set; }
        public string S_IDReaseguro {  get; set; }
        public string U_Corredor {  get; set; }
        public string S_IDCorredor { get; set; }
        public string U_Cedente { get; set; }
        public string S_IDCedente { get; set; }
        public string U_Pais { get; set; }
        public string U_Contrato_Susc { get; set; }
        public string U_NoOferta { get; set; }
        public string U_Endoso { get; set; }
        public string U_Num_aceptacion { get; set; }
        public string U_Operacion { get; set; }
        public string S_IDOperacion { get; set; }
        public string U_Referencia { get; set; }
        public string U_Tipo_Contrato { get; set; }
        public string U_Clasificacion_documento { get; set; }
        public string U_Tipo_documento_Suscripcion { get; set; }
        public string S_SDK { get; set; }
        public string S_Nombre_Original { get; set; }
        public string U_Año_Susc { get; set; }

        public bool ParaProcesar {  get; set; }
        public string Razon {  get; set; }

        public string Plantilla { get; set; }
        public string U_Hoja_de_selección { get; set; }
    }
}
