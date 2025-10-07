using twister.Models;

namespace twister.Repositories;

public interface IThreadRepository
{
    Task<IEnumerable<ThreadModel>> GetThreads();
    Task<IEnumerable<ThreadModel>> GetThreadsByBoardId(int boardId);
    Task<ThreadModel> GetThreadById(int id);
    Task<ThreadModel> CreateThread(ThreadModel thread);
    Task<ThreadModel> UpdateThread(ThreadModel thread);
    Task<ThreadModel> DeleteThread(int id);
}
public class ThreadRepository
//: IThreadRepository
{
    private readonly ApplicationDbContext _context;
    public ThreadRepository(ApplicationDbContext context)
    {
        _context = context;
    }
}
