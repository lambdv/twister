using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace twister.Models;

[Table("boards")]
public class BoardModel
{
    [Key]
    public int BoardId { get; set; }
    public string Name { get; set; } = string.Empty;
    ICollection<ThreadModel> Threads { get; set; } = new List<ThreadModel>();
}

[Table("users")]
public class UserModel : IdentityUser<int>
{
    // [Key]
    // public int UserId { get; set; }
    // public string Username { get; set; } = string.Empty;
    // public string Password { get; set; } = string.Empty;
    // public DateTime CreatedAt { get; set; }
    // public DateTime UpdatedAt { get; set; }

    public ICollection<ThreadModel> Threads { get; set; } = new List<ThreadModel>();
    public ICollection<CommentModel> Comments { get; set; } = new List<CommentModel>();

}

[Table("threads")]
public class ThreadModel
{
    [Key]
    public int ThreadId { get; set; }
    // public UserModel User { get; set; } = null!;
    // public BoardModel Board { get; set; } = null!;

    public String Title { get; set; } = string.Empty;
    public String Content { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

[Table("comments")]
public class CommentModel
{
    [Key]
    public int CommentId { get; set; }
    public int UserId { get; set; }
    public int ThreadId { get; set; }
    public String Content { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

