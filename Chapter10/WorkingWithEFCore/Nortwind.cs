using Microsoft.EntityFrameworkCore;

using WorkingWithEFCore.AutoGen;

namespace Packt.Shared;


public class Northwind : DbContext
{
    public DbSet<Product>? Products { get; set; }
    public DbSet<Category>? Categories { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connection = $"Data Source=T1-BUTKO1;Initial Catalog=Northwind;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=True;";
        optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connection);
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
     .HasQueryFilter(p => !p.Discontinued);
    }
}