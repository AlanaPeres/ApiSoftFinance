using ApiSoftFinance.Domain;
using Microsoft.EntityFrameworkCore;

namespace ApiSoftFinance.Infra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //mapear as entidades
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ContaBancaria> Contas { get; set; }

    }
}
