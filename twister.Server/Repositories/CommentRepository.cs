using twister.Server.Models;
using twister.Server.Interfaces;
using twister.Server.Data;
using twister.Server.Dots;
using twister.Server.Mappers;

using Microsoft.EntityFrameworkCore;

namespace twister.Server.Repositories;
public class CommentRepository : ICommentRepository
{
    private readonly ApplicationDbContext _context;
    public CommentRepository(ApplicationDbContext context) { _context = context; }
    public async Task<List<Comment>> GetAllAsync()
    {
        return await _context.Comments.ToListAsync();
    }

    public async Task<Comment?> GetByIdAsync(int id)
    {
        return await _context.Comments.FirstOrDefaultAsync(x => x.CommentId == id);
    }

    public async Task<List<Comment>> GetByPostIdAsync(int postId)
    {
        return await _context.Comments.Where(x => x.PostId == postId).ToListAsync();
    }

    public async Task<Comment?> CreateAsync(int postId, CreateCommentRequestDto dto)
    {
        var comment = dto.ToCommentFromCreateCommentRequest(postId);
        comment.PostId = postId;
        var commentModel = await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
        return commentModel.Entity;
    }

    public async Task<Comment?> UpdateAsync(int id, UpdateCommentRequestDto dto)
    {
        var model = await _context.Comments.FirstOrDefaultAsync(x => x.CommentId == id);
        if (model == null)
            return null;
        model.Content = dto.Content;
        model.UpdatedAt = DateTime.Now;
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<Comment?> DeleteAsync(int id)
    {
        var model = await _context.Comments.FindAsync(id);
        if (model == null)
            return null;
        _context.Comments.Remove(model);
        await _context.SaveChangesAsync();
        return model;
    }
}