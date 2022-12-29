using Data.Config;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class DatabaseContext : DbContext
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	public DatabaseContext
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		(Microsoft.EntityFrameworkCore.DbContextOptions<DatabaseContext> options) : base(options: options)
	{
		Database.EnsureCreated();
	}

	public DbSet<Product> Products { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly
            (assembly: typeof(Config.ProductConfig).Assembly);

        modelBuilder.ApplyConfiguration(new ProductConfig());

        base.OnModelCreating(modelBuilder);
    }

}
