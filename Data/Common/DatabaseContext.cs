using Data.Config;
using Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Data.Common;

public class DatabaseContext : DbContext
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public DatabaseContext
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        (DbContextOptions<DatabaseContext> options) : base(options: options)
    {
        Database.EnsureCreated();
    }

    //public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    //{

    //}

    public DbSet<Product> Products { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly
            (assembly: typeof(ProductConfig).Assembly);
        //modelBuilder.ApplyConfiguration(new ProductConfig());
        //base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions
            (Microsoft.EntityFrameworkCore.ModelConfigurationBuilder builder)
    {
        builder.Properties<System.DateOnly>()
            .HaveConversion<Conventions.DateTimeConventions.DateOnlyConverter>()
            .HaveColumnType(typeName: nameof(System.DateTime.Date))
            ;

        builder.Properties<System.DateOnly?>()
            .HaveConversion<Conventions.DateTimeConventions.NullableDateOnlyConverter>()
            .HaveColumnType(typeName: nameof(System.DateTime.Date))
            ;
    }
}
