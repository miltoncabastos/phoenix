using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pheonix.Domain.Entities;

namespace Pheonix.Infra.Mapping
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Name)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(prop => prop.Email).IsRequired();
        }
    }
}
