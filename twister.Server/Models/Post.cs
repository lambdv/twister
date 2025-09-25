using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace twister.Server.Models

{
    public class Post 
    {
        public int PostId { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

    }
}
