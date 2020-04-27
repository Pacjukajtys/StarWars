using Microsoft.AspNetCore.Mvc;
using StarWars.Services;

namespace StarWars.Controllers
{
    public class EpisodesController : Controller
    {
        private readonly IPostService _postService;

        public EpisodesController(IPostService postService)
        {
            _postService = postService;
        }

    }
}

