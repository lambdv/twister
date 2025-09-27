using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using twister.Server.Models;
using twister.Server.Data;
using twister.Server.Mappers;
using twister.Server.Dots;
using twister.Server.Interfaces;
namespace twister.Server.Controllers;

[ApiController]
[Route("posts")] // /posts route having different HTTP methods
public class PostController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IPostRepository _postRepo;

    public PostController(ApplicationDbContext context, IPostRepository postRepo)
    {
        _context = context;
        _postRepo = postRepo;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAll() //get request for /post
    {
        var posts = await _postRepo.GetAllAsync();

        var postsDto = posts.Select(x => x.ToDto());
           
        return Ok(posts);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id) //get request for /post/id
    {
        var res = await _context.Posts.FindAsync(id); 
        if (res == null) return NotFound();
        return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePostRequestDto req) //post request for /post
    {
        Post postModel = req.ToPostFromCreatePostRequest();
        _context.Add(postModel);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = postModel.PostId }, postModel);
    }

    [HttpPut]
    [Route("{id:int}")] //route param
    public async Task<IActionResult> Update( //put request for /post/id
        [FromRoute] int id,
        [FromBody] UpdatePostRequestDto dto
    )
    {
        var model = await _context.Posts.FirstOrDefaultAsync(x => x.PostId == id);
        if (model == null) return NotFound();

        model.Content = dto.Content;
        model.Title = dto.Title;
        model.UpdatedAt = DateTime.Now;
   
        await _context.SaveChangesAsync();

        return Ok(model);
    }


    [HttpDelete]
    [Route("{id:int}")] //route param
    public async Task<IActionResult> Update( //put request for /post/id
        [FromRoute] int id
    )
    {
        var model = await _context.Posts.FirstOrDefaultAsync(x => x.PostId == id);

        if (model == null) return NotFound();

        _context.Posts.Remove(model); //not an async function for some reason
        await _context.SaveChangesAsync();

        return NoContent();
    }

}

