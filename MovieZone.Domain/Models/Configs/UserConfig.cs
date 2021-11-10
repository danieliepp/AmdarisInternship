using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieZone.Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieZone.Domain.Models.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.PasswordHash).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired(false);
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.SecurityStamp).IsRequired(false);
            builder.Property(x => x.ConcurrencyStamp).IsRequired(false);
            builder.Property(x => x.LockoutEnd).IsRequired(false);
            builder.Property(x => x.NormalizedEmail).IsRequired(false);
            builder.Property(x => x.NormalizedUserName).IsRequired(false);

        }
    }
}
