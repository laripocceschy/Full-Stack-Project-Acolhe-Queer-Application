using Microsoft.EntityFrameworkCore;

namespace acolhequeer.Models
{
    public class AppDbContextt : DbContext
    {
        public AppDbContextt(DbContextOptions options) : base(options) { }

        public DbSet<Veiculo> Veiculos { get; set; }
    }
}
