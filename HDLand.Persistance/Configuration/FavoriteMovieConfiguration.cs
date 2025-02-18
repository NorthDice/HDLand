using HDLand.Logic.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLand.Persistance.Configuration
{
    public class FavoriteMovieConfiguration : IEntityTypeConfiguration<FavoriteMovieEntity>
    {
        public void Configure(EntityTypeBuilder<FavoriteMovieEntity> builder)
        {
            builder.HasKey(fm => new { fm.UserId, fm.MovieId });

            builder.HasOne(fm => fm.User)
                .WithMany(u => u.FavoriteMovies)
                .HasForeignKey(fm => fm.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
