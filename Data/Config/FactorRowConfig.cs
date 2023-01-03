using Domain.FactorRows;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Config;
public class FactorRowConfig : IEntityTypeConfiguration<FactorRow>
{
    public void Configure(EntityTypeBuilder<FactorRow> builder)
    {
        builder
            .HasKey(e => e.Id)
            .HasName("PK_FactorRow");
        builder.Property(x => x.Id)
            .IsRequired()
            .IsUnicode();
        builder.HasOne(x => x.Factor)
              .WithMany(y => y.FactorRows)
              .HasForeignKey(z => z.FactorId)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_FactorRows_Factors");
        builder.HasOne(x => x.Product)
              .WithMany(y => y.FactorRows)
              .HasForeignKey(z => z.ProductId)
              .OnDelete(DeleteBehavior.NoAction)
              .HasConstraintName("FK_FactorRows_Products");
    }
}
