using System.ComponentModel.DataAnnotations;

namespace twister.Server.Dots;


public class PostDto
{
    public int PostId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? Title { get; set; } = string.Empty;
    
    public string Content { get; set; } = string.Empty;
    public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
}


public class CreatePostRequestDto
{
    public string? Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}

public class UpdatePostRequestDto
{
    public string? Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}
