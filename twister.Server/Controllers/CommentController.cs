using Microsoft.AspNetCore.Mvc;
using twister.Server.Dots;
using twister.Server.Interfaces;
namespace twister.Server.Controllers;

[ApiController]
[Route("comments")]
public class CommentController : ControllerBase
{
    private readonly ICommentRepository _commentRepository;
    public CommentController(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var comments = await _commentRepository.GetAllAsync();
        return Ok(comments);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var comment = await _commentRepository.GetByIdAsync(id);
        if (comment == null)
            return NotFound();
        return Ok(comment);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromRoute] int postId, [FromBody] CreateCommentRequestDto request)
    {
        var comment = await _commentRepository.CreateAsync(postId, request);
        if (comment == null)
            return BadRequest();
        return CreatedAtAction(nameof(GetById), new { id = comment.CommentId }, comment);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto request)
    {
        var comment = await _commentRepository.UpdateAsync(id, request);
        if (comment == null)
            return NotFound();
        return Ok(comment);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var comment = await _commentRepository.DeleteAsync(id);
        if (comment == null)
            return NotFound();
        return NoContent();
    }
}