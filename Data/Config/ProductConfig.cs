using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Config;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .HasKey(e => e.Id)
            .HasName("PK_Product");
        builder.Property(x => x.Id)
            .IsRequired()
            .IsUnicode();
        builder.Property(x => x.Name)   
            .IsRequired();
        builder.Property(x => x.UnitPrice)
            .IsRequired();

    }

}
