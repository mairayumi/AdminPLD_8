namespace wsPLD_8.Models.Pruebas
{
    public interface IOrderRepository
    {
      ICollection<OrderDto> GetAll();
    }

    public class FakeOrderRepository : IOrderRepository
    {
        private readonly List<OrderDto> _data = new()
        {
            new() { Id = 1001, Cliente = "Servimex SA",    Ciudad = "Monterrey", Fecha = new DateOnly(2025,12,01), Estado = "Activo" },
            new() { Id = 1002, Cliente = "Alpha Tech",     Ciudad = "Guadalajara", Fecha = new DateOnly(2025,12,03), Estado = "Pendiente" },
            new() { Id = 1003, Cliente = "Beta Solutions", Ciudad = "CDMX",       Fecha = new DateOnly(2025,12,05), Estado = "Cerrado" },
            new() { Id = 1004, Cliente = "Gamma Corp",     Ciudad = "Puebla",     Fecha = new DateOnly(2025,12,07), Estado = "Activo" },
            new() { Id = 1005, Cliente = "Delta Systems",  Ciudad = "Toluca",     Fecha = new DateOnly(2025,12,10), Estado = "Pendiente" },
            new() { Id = 1006, Cliente = "Omega Labs",     Ciudad = "Querétaro",  Fecha = new DateOnly(2025,12,11), Estado = "Cerrado" },
        };

        public ICollection<OrderDto> GetAll() => _data;
    }
}
