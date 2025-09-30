using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using twister.Server.Models;
using twister.Server.Data;
using twister.Server.Mappers;
using twister.Server.Dots;
using twister.Server.Interfaces;
using twister.Server.Helpers;

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
    public async Task<IActionResult> GetAll(
        // [FromQuery]
        // QueryObject queryParameter
    ) //get request for /post
    {
        
        var posts = await _postRepo.GetAllAsync();
        var postsDto = posts.Select(x => x.ToDto());
        return Ok(posts);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id) //get request for /post/id
    {
        var res = await _postRepo.GetByIdAsync(id); 
        if (res == null) return NotFound();
        return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePostRequestDto req) //post request for /post
    {
        var postModel = await _postRepo.CreateAsync(req);
        return CreatedAtAction(nameof(GetById), new { id = postModel.PostId }, postModel);
    }

    [HttpPut]
    [Route("{id:int}")] //route param
    public async Task<IActionResult> Update( //put request for /post/id
        [FromRoute] int id,
        [FromBody] UpdatePostRequestDto dto
    )
    {
        var model = await _postRepo.UpdateAsync(id, dto);
        return Ok(model);
    }


    [HttpDelete]
    [Route("{id:int}")] //route param
    public async Task<IActionResult> Delete( //put request for /post/id
        [FromRoute] int id
    )
    {
        var res = await _postRepo.DeleteAsync(id);
        if (res == null)
            return NotFound();
        return NoContent();
    }

}

