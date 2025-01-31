using HDLand.Contracts;
using HDLand.Logic.Interfaces;
using HDLand.Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

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
            var movieDataString = await _movieService.GetMovieByIdAsync(id);

            if (string.IsNullOrWhiteSpace(movieDataString))
            {
                return BadRequest("Movie data is empty or malformed.");
            }

            var movieData = JsonConvert.DeserializeObject<MovieModel>(movieDataString);

            if (movieData == null)
            {
                return NotFound("Movie not found.");
            }

            var filteredMovieData = new GetMovieResponse(
                Id: movieData.Id,
                Title: movieData.Title,
                Overview: movieData.Overview,
                PosterPath: movieData.PosterPath,
                ReleaseDate: movieData.ReleaseDate,
                VoteAverage: movieData.VoteAverage.ToString(),
                VoteCount: movieData.VoteCount.ToString()
            );

            return Ok(filteredMovieData);
        }

        [HttpGet("{query}")]
        public async Task<IActionResult> GetMovieByName(string query)
        {
            var movieDataString = await _movieService.GetMovieByNameAsync(query);

            if (string.IsNullOrWhiteSpace(movieDataString))
            {
                return BadRequest("Movie data is empty or malformed.");
            }

            var movieSearchResult = JsonConvert.DeserializeObject<MovieSearchResult>(movieDataString);

            if (!movieSearchResult.Results.Any())
            {
                return BadRequest("Failed to parse movie data.");
            }

            var movieData = movieSearchResult.Results.FirstOrDefault();

            if (movieData == null)
            {
                return NotFound("Movie not found.");
            }

            var filteredMovieData = new GetMovieResponse(
                Id: movieData.Id,
                Title: movieData.Title,
                Overview: movieData.Overview,
                PosterPath: movieData.PosterPath,
                ReleaseDate: movieData.ReleaseDate,
                VoteAverage: movieData.VoteAverage.ToString(),
                VoteCount: movieData.VoteCount.ToString()
            );

            return Ok(filteredMovieData);
        }

        [HttpGet("trending")]
        public async Task<IActionResult> GetAllMovies(string timeWindow = "day")
        {
            if (timeWindow != "day" && timeWindow != "week")
            {
                return BadRequest("Invalid time window. Use 'day' or 'week'.");
            }

            var movieDataString = await _movieService.GetAllMoviesAsync(timeWindow);

            if (string.IsNullOrWhiteSpace(movieDataString))
            {
                return BadRequest("Movie data is empty or malformed.");
            }

            var movieSearchResult = JsonConvert.DeserializeObject<MovieSearchResult>(movieDataString);

            if (movieSearchResult?.Results == null || !movieSearchResult.Results.Any())
            {
                return NotFound("No trending movies found.");
            }

            var filteredMovies = movieSearchResult.Results
                .Select(movie => new GetMovieResponse(
                    Id: movie.Id,
                    Title: movie.Title,
                    Overview: movie.Overview,
                    PosterPath: movie.PosterPath,
                    ReleaseDate: movie.ReleaseDate,
                    VoteAverage: movie.VoteAverage.ToString(),
                    VoteCount: movie.VoteCount.ToString()
                ))
                .ToList();

            return Ok(filteredMovies);
        }
    }
}
