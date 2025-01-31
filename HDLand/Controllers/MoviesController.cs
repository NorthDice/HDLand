using HDLand.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HDLand.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movieData = await _movieService.GetMovieByIdAsync(id);
            return Ok(movieData);
        }
    }
}
