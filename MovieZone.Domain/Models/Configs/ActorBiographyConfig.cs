using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieZone.Domain.Configs
{
    public class ActorBiographyConfig : IEntityTypeConfiguration<ActorBiography>
    {
        public void Configure(EntityTypeBuilder<ActorBiography> builder)
        {
            builder.Property(ab => ab.PlaceOfBirth).HasMaxLength(255);
            builder.Property(ab => ab.Gender).HasMaxLength(255);
        }
    }
}
