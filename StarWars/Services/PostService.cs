using Microsoft.EntityFrameworkCore;
using StarWars.Data;
using StarWars.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWars.Services
{
    public class PostService : IPostService
    {
        private readonly DataContext _dataContext;
        public PostService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            return await _dataContext.Posts.Include(x => x.Episodes).Include(y => y.Friends).ToListAsync();
        }

        public async Task<Post> GetPostByIdAsync(Guid postId)
        {
            return await _dataContext.Posts
                .Include(x => x.Episodes)
                .Include(y => y.Friends)
                .SingleOrDefaultAsync(x => x.Id == postId);
        }

        public async Task<bool> CreatePostAsync(Post post)
        {
            post.Episodes?.ForEach(x => x.EpisodeName = x.EpisodeName.ToLower());
            post.Friends?.ForEach(y => y.FriendName = y.FriendName.ToLower());
            await _dataContext.Posts.AddAsync(post);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> UpdatePostAsync(Post postToUpdate)
        {
            postToUpdate.Episodes?.ForEach(x => x.EpisodeName = x.EpisodeName.ToLower());
            postToUpdate.Friends?.ForEach(y => y.FriendName = y.FriendName.ToLower());
            _dataContext.Posts.Update(postToUpdate);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> DeletePostAsync(Guid postId)
        {
            var post = await GetPostByIdAsync(postId);
            if (post == null)
                return false;
            _dataContext.Posts.Remove(post);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }
    }
}