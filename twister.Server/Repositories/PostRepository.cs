using twister.Server.Models;
using twister.Server.Interfaces;
using twister.Server.Data;
using twister.Server.Dots;
using twister.Server.Mappers;

using Microsoft.EntityFrameworkCore;

namespace twister.Server.Repositories;
public class PostRepository : IPostRepository
{
    private readonly ApplicationDbContext _context;
    public PostRepository(ApplicationDbContext context) { _context = context; }
    public async Task<List<Post>> GetAllAsync()
    {
        return await _context.Posts
            .Include(x => x.Comments)
            .ToListAsync();
    }

    public async Task<List<PostDto>> GetAllPostsAsync()
    {
        var posts = await _context.Posts
            .Include(x => x.Comments)
            .OrderByDecending(x => x.UpdatedAt)
            .ToListAsync()

        ;
        return posts.Select(p => p.ToDto()).ToList();
    }

    public async Task<Post?> GetByIdAsync(int id)
    {
        return await _context.Posts.Include(x => x.Comments).FirstOrDefaultAsync(x => x.PostId == id);
    }
    public async Task<Post> CreateAsync(CreatePostRequestDto request)
    {
        Post postModel = request.ToPostFromCreatePostRequest();
        postModel.Comments = new List<Comment>();
        _context.Add(postModel);
        await _context.SaveChangesAsync();
        return postModel;
    }
    public async Task<Post?> UpdateAsync(int id, UpdatePostRequestDto dto)
    {
        var model = await _context.Posts.FirstOrDefaultAsync(x => x.PostId == id);
        if (model == null)
            return null;
        model.Content = dto.Content;
        model.Title = dto.Title;
        model.UpdatedAt = DateTime.Now;
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<Post?> DeleteAsync(int id)
    {
        var model = await _context.Posts.FirstOrDefaultAsync(x => x.PostId == id);
        if (model == null)
            return null;
        _context.Posts.Remove(model); //not an async function for some reason
        await _context.SaveChangesAsync();
        return model;
    }
}