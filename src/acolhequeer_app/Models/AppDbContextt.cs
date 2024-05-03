using acolhequeer_app.Models;
using Microsoft.EntityFrameworkCore;

namespace acolhequeer.Models
{
    public class AppDbContextt : DbContext
    {
        public AppDbContextt(DbContextOptions options) : base(options) { }

        public DbSet<Veiculo> Veiculos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
