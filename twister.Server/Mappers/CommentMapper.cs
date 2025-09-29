using twister.Server.Dots;
using twister.Server.Models;

namespace twister.Server.Mappers;

public static class CommentMapper
{
    // public static CommentDto ToDto(this Comment comment)
    // {
    //     return new CommentDto
    //     {
    //         CommentId = comment.CommentId,
    //         CreatedAt = comment.CreatedAt,
    //         UpdatedAt = comment.UpdatedAt,
    //         Content = comment.Content
    //     };
    // }

    public static Comment ToCommentFromCreateCommentRequest(this CreateCommentRequestDto dto, int postId)
    {
        var date = DateTime.Now;
        return new Comment
        {
            CreatedAt = date,
            UpdatedAt = date,
            Content = dto.Content,
            PostId = postId
        };
    }

    public static Comment ToCommentFromUpdateCommentRequest(this UpdateCommentRequestDto dto, int postId)
    {
        var updatedAt = DateTime.Now;
        return new Comment
        {
            UpdatedAt = updatedAt,
            Content = dto.Content,
            PostId = postId
        };
    }

    public static CommentDto ToDto(this Comment comment)
    {
        return new CommentDto
        {
            CommentId = comment.CommentId,
            CreatedAt = comment.CreatedAt,
            UpdatedAt = comment.UpdatedAt,
            Content = comment.Content,
            PostId = comment.PostId
        };
    }

}