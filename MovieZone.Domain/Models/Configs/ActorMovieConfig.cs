using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieZone.Domain.Models.Configs
{
    public class ActorMovieConfig : IEntityTypeConfiguration<ActorMovie>
    {
        public void Configure(EntityTypeBuilder<ActorMovie> builder)
        {
            builder.HasKey(m => new { m.MovieId, m.ActorId });
            builder.HasOne(m => m.Movie)
                .WithMany(m => m.ActorMovies)
                .HasForeignKey(m => m.MovieId);
            builder.HasOne(g => g.Actor)
                .WithMany(g => g.ActorMovies)
                .HasForeignKey(g => g.ActorId);
        }
    }
}
