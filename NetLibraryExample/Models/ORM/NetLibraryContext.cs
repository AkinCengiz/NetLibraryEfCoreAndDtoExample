using Microsoft.EntityFrameworkCore;
using NetLibraryExample.Models.DTOs;

namespace NetLibraryExample.Models.ORM;

public class NetLibraryContext : DbContext
{
    public NetLibraryContext(DbContextOptions<NetLibraryContext> options) : base(options)
    {
        
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().Property(c => c.Name).HasAnnotation("MinLength", 3);
        modelBuilder.Entity<Product>().Property(p => p.UnitPrice).HasPrecision(9, 2);
        modelBuilder.Entity<Product>().Property(p => p.StockAmount).HasAnnotation("MinValue", 0);
        modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(30);
        modelBuilder.Entity<Customer>().Property(c => c.PostalCode).HasColumnType("char(5)");
        base.OnModelCreating(modelBuilder);
    }

}