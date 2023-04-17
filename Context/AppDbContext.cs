using ApiSoftFinance.Domain;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiSoftFinance.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}     
        //mapear as entidades
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ContaBancaria> Contas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
    

        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
            .HasOne(c => c.ContaBancaria)
            .WithOne(cb => cb.Cliente)
            .HasForeignKey<ContaBancaria>(cb => cb.ClienteId)
            .IsRequired();

            modelBuilder.Entity<Transacao>()
                .HasKey(t => t.Id);
                

        }



    }

    
}
