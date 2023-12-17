using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class CarroMapping : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Marca)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(c => c.Modelo)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.ToTable("Carros");
        }
    }
}
