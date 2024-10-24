using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;
using P1.API.Model;

namespace P1.API.Data;

public partial class MASHContext : DbContext
{
    public MASHContext(){}
    public MASHContext(DbContextOptions<MASHContext> options) : base(options){}

    public virtual DbSet<Category> Categories {get; set; }
    public virtual DbSet<Game> Games {get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>()
            .HasMany(e => e.Categories)
            .WithOne(e => e.Game)
            .HasForeignKey(e => e.GameId)
            .HasPrincipalKey(e => e.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}