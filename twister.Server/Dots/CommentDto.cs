namespace twister.Server.Dots;

public class CommentDto
{
    public int CommentId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Content { get; set; } = string.Empty;
    public int PostId { get; set; }
}

public class CreateCommentRequestDto
{
    public string Content { get; set; } = string.Empty;
}

public class UpdateCommentRequestDto
{
    public string Content { get; set; } = string.Empty;
}
