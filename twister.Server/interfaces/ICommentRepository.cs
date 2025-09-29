using twister.Server.Models;
using twister.Server.Dots;
namespace twister.Server.Interfaces;
public interface ICommentRepository
{
    public Task<List<Comment>> GetAllAsync();
    public Task<Comment?> GetByIdAsync(int id);
    public Task<List<Comment>> GetByPostIdAsync(int postId);

    public Task<Comment?> CreateAsync(int postId, CreateCommentRequestDto request);
    public Task<Comment?> UpdateAsync(int id, UpdateCommentRequestDto dto);
    public Task<Comment?> DeleteAsync(int id);
}