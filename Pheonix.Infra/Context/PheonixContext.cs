using Microsoft.EntityFrameworkCore;
using Pheonix.Domain.Entities;
using Pheonix.Infra.Mapping;

namespace Pheonix.Infra.Context
{
    public class PheonixContext : DbContext
    {
        public PheonixContext(DbContextOptions<PheonixContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>(new ClientMap().Configure);
            modelBuilder.Entity<Product>(new ProductMap().Configure);
            modelBuilder.Entity<Stock>(new StockMap().Configure);
        }
    }
}
