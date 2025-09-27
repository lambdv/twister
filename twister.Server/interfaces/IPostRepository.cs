using twister.Server.Models;
namespace twister.Server.Interfaces;
public interface IPostRepository
{
    Task<List<Post>> GetAllAsync();
}