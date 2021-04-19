using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pheonix.Domain.Entities;

namespace Pheonix.Infra.Mapping
{
    public class StockMap : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stock");

            builder.HasKey(prop => prop.Id);

            builder.HasOne(prop => prop.Client)
                .WithMany()
                .HasForeignKey(prop => prop.ClientId);

            builder.HasOne(prop => prop.Product)
                .WithMany()
                .HasForeignKey(prop => prop.ProductId);
        }
    }
}
