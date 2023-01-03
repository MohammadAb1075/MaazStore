using Domain.Factors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Config;

public class FactorConfig : IEntityTypeConfiguration<Factor>
{
    public void Configure(EntityTypeBuilder<Factor> builder)
    {
        builder
            .HasKey(e => e.Id)
            .HasName("PK_Factor");
        builder.Property(x => x.Id)
            .IsRequired()
            .IsUnicode();
        builder
            .HasIndex(x => new { x.FactorNo })
            .IsUnique(unique: true)
            ;
    }
}
