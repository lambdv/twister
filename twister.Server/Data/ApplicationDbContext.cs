namespace twister.Server.Data;
using Microsoft.EntityFrameworkCore;
using twister.Server.Models;

namespace twister.Server.Data;
public class ApplicationDbContext : DbContext{
    
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<User> Users { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options){}
}
