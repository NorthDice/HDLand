using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLand.Logic.Interfaces
{
    public interface IMovieService
    {
        Task<string> GetMovieByIdAsync(int movieId);
        Task<string> GetMovieByNameAsync(string query);
        Task<string> GetAllMoviesAsync(string timeWindow = "day");
        Task<string> GetMovieByNameAsync(string query, int page = 1, int pageSize = 20);
        Task<bool> MovieExistsAsync(int movieId);

    }
}
