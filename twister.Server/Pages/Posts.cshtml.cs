using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using twister.Server.Dots;
using twister.Server.Interfaces;

namespace twister.Server.Pages;

public class PostsModel : PageModel
{
    private readonly IPostRepository _postRepository;
    private readonly ILogger<PostsModel> _logger;

    public PostsModel(IPostRepository postRepository, ILogger<PostsModel> logger)
    {
        _postRepository = postRepository;
        _logger = logger;
    }

    public List<PostDto>? Posts { get; set; }

    public async Task OnGetAsync()
    {
        Posts = await _postRepository.GetAllPostsAsync();
    }
}
