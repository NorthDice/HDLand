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
    }
}
