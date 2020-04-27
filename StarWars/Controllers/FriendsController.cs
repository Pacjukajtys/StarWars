using Microsoft.AspNetCore.Mvc;
using StarWars.Services;

namespace StarWars.Controllers
{
    public class FriendsController : Controller
    {
        private readonly IPostService _postService;

        public FriendsController(IPostService postService)
        {
            _postService = postService;
        }


    }
}
