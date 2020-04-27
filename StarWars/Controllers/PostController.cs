using Microsoft.AspNetCore.Mvc;
using StarWars.Contracts;
using StarWars.Contracts.Requests;
using StarWars.Contracts.Responses;
using StarWars.Models;
using StarWars.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        
        [HttpGet(ApiRoutes.Posts.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _postService.GetPostsAsync());
        }

        [HttpPut(ApiRoutes.Posts.Update)]
        public async Task<IActionResult> Get([FromRoute]Guid postId, [FromBody] UpdatePostRequest request)
        {
            var post = await _postService.GetPostByIdAsync(postId);
            post.Name = request.Name;
            post.Planet = request.Planet;
            post.Episodes = request.Episodes.Select(x => new PostEpisode { EpisodeName = x }).ToList();
            post.Friends = request.Friends.Select(x => new PostFriend { FriendName = x }).ToList();

            var updated = await _postService.UpdatePostAsync(post);
            if (updated)
                return Ok(post);
            return NotFound();
        }

        [HttpDelete(ApiRoutes.Posts.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid postId)
        {
            var delete = await _postService.DeletePostAsync(postId);
            if (delete)
                return NoContent();
            return NotFound();
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public async Task<IActionResult> Get([FromRoute]Guid postId)
        {
            var post = await _postService.GetPostByIdAsync(postId);
            if (post == null)
                return NotFound();
            return Ok(post);
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public async Task<IActionResult> Create([FromBody] CreatePostRequest postRequest)
        {
            var newPostId = Guid.NewGuid();
            var post = new Post 
            { 
                Id = Guid.NewGuid(),
                Name = postRequest.Name, 
                Planet = postRequest.Planet,
                Episodes = postRequest.Episodes.Select(x => new PostEpisode { PostId = newPostId, EpisodeName = x }).ToList(),
                Friends = postRequest.Friends.Select(x=> new PostFriend { PostId = newPostId, FriendName = x}).ToList()
            }; 

            await _postService.CreatePostAsync(post);
            var baseUrl = $"{ HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Posts.Get.Replace("{postId}", post.Id.ToString());
            var response = new PostResponse { Id = post.Id };
            return Created(locationUri, response);

        }
    }
}
