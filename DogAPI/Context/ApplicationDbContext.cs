using DogAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DogAPI.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<Cachorro> Cachorros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Veterinario>()
              .Property(p => p.Email)
                .HasMaxLength(80);

            modelBuilder.Entity<Veterinario>()
                .Property(p => p.Consultorio)
                    .HasMaxLength(50);

            modelBuilder.Entity<Veterinario>()
                .Property(p => p.CRMV)
                    .HasMaxLength(50);

            modelBuilder.Entity<Veterinario>()
                .Property(p => p.Endereco)
                    .HasMaxLength(150);

            modelBuilder.Entity<Cliente>()
              .Property(p => p.Email)
                .HasMaxLength(80);

            modelBuilder.Entity<Cliente>()
              .Property(p => p.Endereco)
                .HasMaxLength(150);

            modelBuilder.Entity<Cliente>()
              .Property(p => p.Nome)
                .HasMaxLength(100);

            modelBuilder.Entity<Cliente>()
              .Property(p => p.Bairro)
                .HasMaxLength(100);

            modelBuilder.Entity<Cliente>()
              .Property(p => p.Cidade)
                .HasMaxLength(100);


            modelBuilder.Entity<Cliente>()
              .Property(p => p.Cidade)
                .HasMaxLength(100);

            modelBuilder.Entity<Cachorro>()
              .Property(p => p.Nome)
                .HasMaxLength(100);

            modelBuilder.Entity<Cachorro>()
              .Property(p => p.Vacinas)
                .HasMaxLength(200);

            modelBuilder.Entity<Cachorro>()
              .Property(p => p.Pedigree)
                .HasMaxLength(50);

            modelBuilder.Entity<Cachorro>()
              .Property(p => p.Porte)
                .HasMaxLength(50);


            modelBuilder.Entity<Atendimento>()
              .Property(p => p.Diagnostico)
                .HasMaxLength(300);

            modelBuilder.Entity<Atendimento>()
              .Property(p => p.Comentario)
                .HasMaxLength(300);

            base.OnModelCreating(modelBuilder);
        }
    }
}