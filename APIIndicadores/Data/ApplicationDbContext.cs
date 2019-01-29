using Microsoft.EntityFrameworkCore;
using APIIndicadores.Models;

namespace APIIndicadores.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) :
            base(options)
        {
        }

        public DbSet<Indicador> Indicadores { get; set; }
        public DbSet<BolsaValores> BolsasValores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Indicador>()
                .HasKey(i => i.Sigla);
            modelBuilder.Entity<BolsaValores>()
                .HasKey(b => b.Sigla);
        }
    }
}