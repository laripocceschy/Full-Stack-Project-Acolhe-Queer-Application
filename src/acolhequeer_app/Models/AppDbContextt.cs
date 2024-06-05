using acolhequeer_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Entity;

namespace acolhequeer.Models
{
    public class AppDbContextt : DbContext
    {
        public AppDbContextt(DbContextOptions options) : base(options) { }

        public DbSet<Veiculo> Veiculos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Instituicao> Instituicao { get; set; }

        public DbSet<AgendaQuarto> agendaQuartos { get; set; }
    }
}
