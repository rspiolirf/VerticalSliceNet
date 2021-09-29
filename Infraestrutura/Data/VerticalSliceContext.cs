using Microsoft.EntityFrameworkCore;
using VerticalSlice.Dominio.Entidades;

namespace VerticalSlice.Infraestrutura.Data
{
    public class VerticalSliceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=VerticaSlice.db");
        }

        public DbSet<Medico> Medicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medico>().ToTable("Medico");
        }
    }
}