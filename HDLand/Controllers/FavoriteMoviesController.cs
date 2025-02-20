using AutoMapper;
using HDLand.Logic.Interfaces;
using HDLand.Persistance.Repositories;
using Microsoft.AspNetCore.Mvc;
using HDLand.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HDLand.Contracts;
using Newtonsoft.Json;
using System.Diagnostics;
using HDLand.Logic.Models;

namespace HDLand.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FavoriteMoviesController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IFavoriteMovieRepository _favoriteMovieRepository;
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public FavoriteMoviesController(IUserRepository userRepository, IFavoriteMovieRepository favoriteMovieRepository, IMovieService movieService, IMapper mapper)
        {
            _userRepository = userRepository;
            _favoriteMovieRepository = favoriteMovieRepository;
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpPost("add-to-favorites")]
        public async Task<IActionResult> AddToFavorites([FromBody] AddFavoriteMovieRequest request)
        {

            var user = await _userRepository.GetByEmail(request.Email);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var movieExists = await _movieService.MovieExistsAsync(request.MovieId);
            if (!movieExists)
            {
                return NotFound("Movie not found");
            }

            var userId = user.Id;

            await _favoriteMovieRepository.AddToFavorite(userId, request.MovieId);

            return Ok("Movie added to favorites");
        }

        [HttpPost("remove-from-favorites")]
        public async Task<IActionResult> RemoveFromFavorites([FromBody] AddFavoriteMovieRequest request)
        {
            var user = await _userRepository.GetByEmail(request.Email);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var movieExists = await _movieService.MovieExistsAsync(request.MovieId);
            if (!movieExists)
            {
                return NotFound("Movie not found");
            }

            var userId = user.Id;

            await _favoriteMovieRepository.RemoveFromFavorite(userId, request.MovieId);

            return Ok("Movie removed from favorites");
        }

        [HttpGet("get-favorites")]
        public async Task<IActionResult> GetFavoriteMovies([FromQuery] string email)
        {
            var user = await _userRepository.GetByEmail(email);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var favoriteMovieIds = await _favoriteMovieRepository.GetFavoriteMovieIds(user.Id);
            var favoriteMovies = new List<GetMovieResponse>();

            foreach (var movieId in favoriteMovieIds)
            {
                var movieJson = await _movieService.GetMovieByIdAsync(movieId);
                var movie = JsonConvert.DeserializeObject<MovieModel>(movieJson);

                var responseMovieData = new GetMovieResponse(
                    Id: movie.Id,
                    Title: movie.Title,
                    Overview: movie.Overview,
                    PosterPath: movie.PosterPath,
                    ReleaseDate: movie.ReleaseDate,
                    VoteAverage: movie.VoteAverage.ToString(),
                    VoteCount: movie.VoteCount.ToString()
                );

                favoriteMovies.Add(responseMovieData);
            }
            return Ok(favoriteMovies);
        }
    }

}

