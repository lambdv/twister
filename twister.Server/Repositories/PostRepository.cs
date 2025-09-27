using twister.Server.Models;
using twister.Server.Interfaces;
using twister.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace twister.Server.Repositories;
public class PostRepository : IPostRepository {
    private readonly ApplicationDbContext _context;
    public PostRepository(ApplicationDbContext context){ _context = context;}
    public async Task<List<Post>> GetAllAsync() {
        return await _context.Posts.ToListAsync();
    }
}