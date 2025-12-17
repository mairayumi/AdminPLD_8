namespace waPLD.Models.Shared
{
    public class Respuesta
    {
        public Respuesta()
        {
            exito = 1;
        }
        public int exito { get; set; }
        public string mensaje { get; set; }
        public object Data { get; set; }
    }
}
