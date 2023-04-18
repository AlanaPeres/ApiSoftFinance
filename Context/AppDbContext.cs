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

       
        /*  public void OnModelCreating(ModelBuilder modelBuilder)
           {
               modelBuilder.Entity<Cliente>()
               .HasOne(cb => cb.Cpf)
               .WithOne(c => c.Cpf)
               .HasKey(t => t.Cpf)
               .IsRequired();

               modelBuilder.Entity<Transacao>()
                   .HasKey(t => t.Cpf);

               modelBuilder.Entity<ContaBancaria>()
                  .HasKey(x => x.ContaBancariaId);

           }*/



    }

    
}
