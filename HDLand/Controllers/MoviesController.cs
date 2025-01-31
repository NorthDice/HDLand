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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movieData = await _movieService.GetMovieByIdAsync(id);
            return Ok(movieData);
        }

        [HttpGet("{query}")]
        public async Task<IActionResult> GetMovieByName(string query)
        {
            var movieData = await _movieService.GetMovieByNameAsync(query);
            return Ok(movieData);
        }
    }
}
