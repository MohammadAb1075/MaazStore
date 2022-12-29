using Domain.Products;
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
        builder.HasData(new Product[]
            {
                    new Product
                    {
                        Id = 1,
                        Name = "Mobile_Apple iPhone 13",
                        UnitPrice = 30_000_000
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Mobile_Samsung Galaxy F42 5G",
                        UnitPrice = 25_000_000
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Mobile_Xiaomi Poco C31",
                        UnitPrice = 8_000_000
                    },
                    new Product
                    {
                        Id = 4,
                        Name = "Mobile_Xiaomi Redmi Note 10 Lite",
                        UnitPrice = 8_000_000
                    },
                    new Product
                    {
                        Id = 5,
                        Name = "Laptop_ASUS Zenbook 14X OLED",
                        UnitPrice = 45_000_000
                    },
                    new Product
                    {
                        Id = 6,
                        Name = "Laptop_ASUS ExpertBook B7",
                        UnitPrice = 33_000_000
                    },
                    new Product
                    {
                        Id = 7,
                        Name = "Laptop_ProArt Studiobook 16",
                        UnitPrice = 53_000_000
                    },
                    new Product
                    {
                        Id = 8,
                        Name = "Laptop_ASUS ProArt Display PA278CV",
                        UnitPrice = 38_000_000
                    },
                    new Product
                    {
                        Id = 9,
                        Name = "PC_Sleek and ultra-portable with a Zen-inspired design",
                        UnitPrice = 19_000_000
                    },
                    new Product
                    {
                        Id = 10,
                        Name = "PC_Ultracompact mini PC ",
                        UnitPrice = 12_000_000
                    }
            }
            );
    }
}
