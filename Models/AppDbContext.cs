
using Microsoft.EntityFrameworkCore;

namespace CompanySelfService.Pet.Models;

public class AppDbContext : DbContext
{
    public DbSet<User> Users {get; set;}

    public DbSet<BuildingObject> BuildingObjects {get; set;}
    public DbSet<AccessPass> AccessPasses {get; set;}


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<AccessPass>()
        .HasOne(p => p.User)
        .WithMany(u => u.Passes)
        .HasForeignKey(p => p.UserId)
        .OnDelete(DeleteBehavior.Cascade); 

    modelBuilder.Entity<AccessPass>()
        .HasOne(p => p.BuildingObject)
        .WithMany(b => b.Passes)
        .HasForeignKey(p => p.BuildingObjectId)
        .OnDelete(DeleteBehavior.Cascade);

    modelBuilder.Entity<AccessPass>()
        .HasOne(p => p.IssuedBy)
        .WithMany()
        .HasForeignKey(p => p.IssuedByUserId)
        .OnDelete(DeleteBehavior.Restrict); 
}


} 
