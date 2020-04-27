using StarWars.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWars.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetPostsAsync();
        Task<bool> CreatePostAsync(Post post);
        Task<Post> GetPostByIdAsync(Guid postId);
        Task<bool> UpdatePostAsync(Post updateToPost);
        Task<bool> DeletePostAsync(Guid postId);
    }
}
