using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieZone.Domain.Models.Configs
{
    public class GenreMovieConfig : IEntityTypeConfiguration<GenreMovie>
    {
        public void Configure(EntityTypeBuilder<GenreMovie> builder)
        {
            builder.HasKey(m => new { m.MovieId, m.GenreId });
            builder.HasOne(m => m.Movie)
                .WithMany(m => m.GenresMovies)
                .HasForeignKey(m => m.MovieId);
            builder.HasOne(g => g.Genre)
                .WithMany(g => g.GenresMovies)
                .HasForeignKey(g => g.GenreId);

        }
    }
}
