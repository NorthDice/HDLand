using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLand.Logic.Interfaces
{
    public interface IFavoriteMovieRepository
    {
        Task AddToFavorite(Guid userId, int movieId);
        Task RemoveFromFavorite(Guid userId, int movieId);
        Task<IEnumerable<int>> GetFavoriteMovieIds(Guid userId);
    }
}
