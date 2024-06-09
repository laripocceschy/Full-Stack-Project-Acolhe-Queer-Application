using Microsoft.EntityFrameworkCore;

namespace acolhequeer.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Instituicao> Instituicoes { get; set; }

        public DbSet<ReservaQuarto> ReservaQuartos { get; set; }

        public DbSet<AtendimentoPsi> AtendimentosPsicologico { get; set; }

    }
}
