using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieZone.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieZone.Domain.Configs
{
    public class MovieConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(m => m.Title).HasMaxLength(255);
            builder.Property(m => m.Description).HasMaxLength(4000);
            builder.Property(m => m.Title).HasMaxLength(255);
            builder.Property(m => m.Poster).IsRequired(false);
           
        }
    }
}
