namespace waPLD_8.Models.Solicitudes
{
    public class Resultado
    {
        public int cSOL_Id { get; set; }
        public int Estatus { get; set; }
        public int NumeroArchivos { get; set; }
        public string Observaciones { get; set; }
        public int cSCO_Id { get; set; }
        public string S_Ticket { get; set; }
        public string ListArchivos { get; set; }
        public string ListMail { get; set; }

    }
}