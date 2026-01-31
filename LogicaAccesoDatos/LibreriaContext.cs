using LogicaDeNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class LibreriaContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Atleta> Atletas { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public LibreriaContext(DbContextOptions opt) : base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurar clave primaria compuesta en Puntaje
            modelBuilder.Entity<Puntaje>()
                .HasKey(p => new { p.AtletaId, p.EventoId });

            // Relación Evento -> Disciplina
            modelBuilder.Entity<Evento>()
                .HasOne(e => e.Disciplina)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Evento -> Puntajes
            modelBuilder.Entity<Evento>()
                .HasMany(e => e.Puntajes)
                .WithOne()
                .HasForeignKey(p => p.EventoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Puntaje -> Atleta
            modelBuilder.Entity<Puntaje>()
                .HasOne(p => p.Atleta)
                .WithMany()
                .HasForeignKey(p => p.AtletaId)
                .OnDelete(DeleteBehavior.Restrict);
            // Relación Puntaje -> Evento
            modelBuilder.Entity<Puntaje>()
                .HasOne<Evento>() // Sin navegación inversa desde Evento a Puntaje
                .WithMany(e => e.Puntajes)
                .HasForeignKey(p => p.EventoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
