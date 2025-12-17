namespace wsPLD_8.Models.Pruebas
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Cliente { get; set; } = "";
        public string Ciudad { get; set; } = "";
        public DateOnly Fecha { get; set; }
        public string Estado { get; set; } = "";

    }
}
