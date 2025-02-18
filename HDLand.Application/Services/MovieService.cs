using HDLand.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using HDLand.Logic.Models;
using System.Collections;

namespace HDLand.Application.Services
{
    public class MovieService : IMovieService
    {
        public async Task<string> GetMovieByIdAsync(int movieId)
        {
            var client = ApiClientFactory.CreateClient($"/movie/{movieId}?language=en-US");
            var request = RequestFactory.CreateRequest();

            var response = await client.GetAsync(request);
            if (!response.IsSuccessful)
            {
                throw new Exception($"Error fetching movie: {response.ErrorMessage}");
            }

            return response.Content ?? string.Empty;
        }

        public async Task<string> GetMovieByNameAsync(string query)
        {
            var client = ApiClientFactory.CreateClient($"/search/movie?query={Uri.EscapeDataString(query)}&include_adult=false&language=en-US&page=1");
            var request = RequestFactory.CreateRequest();

            var response = await client.GetAsync(request);
            if (!response.IsSuccessful)
            {
                throw new Exception($"Error fetching movie by name: {response.ErrorMessage}");
            }

            return response.Content ?? string.Empty;
        }

        public async Task<string> GetMovieByNameAsync(string query, int page = 1, int pageSize = 20)
        {
            var client = ApiClientFactory.CreateClient($"/search/movie?query={Uri.EscapeDataString(query)}&include_adult=false&language=en-US&page={page}&page_size={pageSize}");
            var request = RequestFactory.CreateRequest();

            var response = await client.GetAsync(request);
            if (!response.IsSuccessful)
            {
                throw new Exception($"Error fetching movie by name: {response.ErrorMessage}");
            }

            return response.Content ?? string.Empty;
        }


        public async Task<string> GetAllMoviesAsync(string timeWindow = "day")
        {
            if (timeWindow != "day" && timeWindow != "week")
            {
                throw new ArgumentException("Invalid time window. Use 'day' or 'week'.");
            }

            var client = ApiClientFactory.CreateClient($"/trending/movie/{timeWindow}?language=en-US");
            var request = RequestFactory.CreateRequest();

            var response = await client.GetAsync(request);
            if (!response.IsSuccessful)
            {
                throw new Exception($"Error fetching trending movies: {response.ErrorMessage}");
            }

            return response.Content ?? string.Empty;
        }
         
        public async Task<bool> MovieExistsAsync (int movieId)
        {
            var client = ApiClientFactory.CreateClient($"/movie/{movieId}?language=en-US");
            var request = RequestFactory.CreateRequest();

            var response = await client.GetAsync(request);
            if (!response.IsSuccessful)
            {
                return false;
            }

            return true;

        }
    }
}
