
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CompanySelfService.Pet.Models;

public class AppDbContext : DbContext
{
    public DbSet<User> Users {get; set;}

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

} 

class fabric : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=pet_service_db;Username=my_db_user;Password=my_secure_password");
        
        return new AppDbContext(optionsBuilder.Options);

    }
}