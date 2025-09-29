
using twister.Server.Dots;
using twister.Server.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace twister.Server.Mappers
{
    public static class PostMappers
    {
        public static PostDto ToDto(this Post postModel)
        {
            return new PostDto
            {
                PostId = postModel.PostId,
                CreatedAt = postModel.CreatedAt,
                UpdatedAt = postModel.UpdatedAt,
                Title = postModel.Title,
                Content = postModel.Content,
                Comments = postModel.Comments.Select(x => x.ToDto()).ToList()
            };
        }

        public static Post ToPostFromCreatePostRequest(this CreatePostRequestDto dto)
        {
            var date = DateTime.Now;
            return new Post
            {
                CreatedAt = date,
                UpdatedAt = date,
                Title = dto.Title,
                Content = dto.Content
            };
        }

        public static Post ToPostFromUpdatePostRequest(this UpdatePostRequestDto dto)
        {
            var updatedAt = DateTime.Now;
            return new Post
            {
                UpdatedAt = updatedAt,
                Title = dto.Title,
                Content = dto.Content
            };
        }

    }
}
