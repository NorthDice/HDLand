using HDLand.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace HDLand.Application.Services
{
    public class MovieService : IMovieService
    {
        private const string BaseUrl = "https://api.themoviedb.org/3/movie/";
        private const string ApiKey = "9f7eb71acfe6b84fac596f13b819d406"; 
        private const string BearerToken = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI5ZjdlYjcxYWNmZTZiODRmYWM1OTZmMTNiODE5ZDQwNiIsIm5iZiI6MTczODIzMzg5MC42NzIsInN1YiI6IjY3OWI1ODIyYjAwZDNiYWQ5MmJkNzg3NyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.W4c6yfcHMWuZhnhNDXpsFFWBfXC2k_DdmPnR12q3vGo"; 

        public async Task<string> GetMovieByIdAsync(int movieId)
        {
            var options = new RestClientOptions($"{BaseUrl}{movieId}?language=en-US");
            var client = new RestClient(options);
            var request = new RestRequest();

            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {BearerToken}");

            var response = await client.GetAsync(request);

            if (!response.IsSuccessful)
            {
                throw new ArgumentNullException ($"Error fetching movie: {response.ErrorMessage}");
            }

            return response.Content ?? string.Empty;
        }
    }
}
