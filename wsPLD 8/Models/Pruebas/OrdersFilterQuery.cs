namespace wsPLD_8.Models.Pruebas
{
    public class OrdersFilterQuery
    {
        public string? Id { get; set; }
        public string? Cliente { get; set; }
        public string? Ciudad { get; set; }
        public DateOnly? Desde { get; set; }   
        public DateOnly? Hasta { get; set; } 
        public string? Estado { get; set; }

    }
}
