namespace Lobby.Database;

using Lobby.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    
    public DbSet<UserModel>? UserModels { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = Guid.NewGuid().ToString(), Name = AppUserRole.Admin, NormalizedName = AppUserRole.Admin.ToUpperInvariant() });
        builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = Guid.NewGuid().ToString(), Name = AppUserRole.User, NormalizedName = AppUserRole.User.ToUpperInvariant() });
    }
}