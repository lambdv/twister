using twister.Server.Models;
using twister.Server.Dots;
namespace twister.Server.Interfaces;
public interface IPostRepository
{
    public Task<List<Post>> GetAllAsync();
    public Task<List<PostDto>> GetAllPostsAsync();
    public Task<Post?> GetByIdAsync(int id);
    public Task<Post> CreateAsync(CreatePostRequestDto request);
    public Task<Post?> UpdateAsync(int id, UpdatePostRequestDto dto);
    public Task<Post?> DeleteAsync(int id);
}