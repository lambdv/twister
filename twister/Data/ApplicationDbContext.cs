using Microsoft.EntityFrameworkCore;
using twister.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace twister;
public class ApplicationDbContext : IdentityDbContext<UserModel, IdentityRole<int>, int>
//: DbContext
{
    // public DbSet<UserModel> Users { get; set; }
    public DbSet<BoardModel> Boards { get; set; }
    public DbSet<ThreadModel> Threads { get; set; }
    public DbSet<CommentModel> Comments { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // modelBuilder.Entity<UserModel>();
        modelBuilder.Entity<BoardModel>();
        modelBuilder.Entity<ThreadModel>();
        modelBuilder.Entity<CommentModel>();
    }
}