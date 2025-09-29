using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace twister.Server.Models;

public class Comment
{
    [Key] public int CommentId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Content { get; set; } = string.Empty;
    // [ForeignKey]
    public int PostId { get; set; }
}