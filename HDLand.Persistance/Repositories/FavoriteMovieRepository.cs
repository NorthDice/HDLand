using HDLand.Logic.Entities;
using HDLand.Logic.Interfaces;
using HDLand.Persistance.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLand.Persistance.Repositories
{
    public class FavoriteMovieRepository : IFavoriteMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public FavoriteMovieRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddToFavorite(Guid userId, int movieId)
        {
            var favoriteMovieEntity = new FavoriteMovieEntity
            {
                UserId = userId,
                MovieId = movieId
            };

            await _context.FavoriteMovies.AddAsync(favoriteMovieEntity);
            await _context.SaveChangesAsync();
        }

        
        public async Task RemoveFromFavorite(Guid userId, int movieId)
        {
            var favoriteMovieEntity = await _context.FavoriteMovies
                .FirstOrDefaultAsync(f => f.UserId == userId && f.MovieId == movieId);

            if (favoriteMovieEntity != null)
            {
                _context.FavoriteMovies.Remove(favoriteMovieEntity);
                await _context.SaveChangesAsync();
            }
        }

        
        public async Task<IEnumerable<int>> GetFavoriteMovieIds(Guid userId)
        {
            return await _context.FavoriteMovies
                .Where(f => f.UserId == userId)
                .Select(f => f.MovieId)
                .ToListAsync();
        }
    }
}
