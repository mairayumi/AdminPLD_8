using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using wsPLD_8.Models.Shared;

namespace wsPLD_8.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuarios>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // Si quieres otras tablas personalizadas:
        //public DbSet<Usuarios> Usuario { get; set; }
    }
}
