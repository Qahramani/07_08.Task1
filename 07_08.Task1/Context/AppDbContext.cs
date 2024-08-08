using _07_08.Task1.Models;
using Microsoft.EntityFrameworkCore;

namespace _07_08.Task1.Context;

public class AppDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=Ruhel\\SQLEXPRESS;database=ORMTask2;trusted_connection=true");
        base.OnConfiguring(optionsBuilder);
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}
