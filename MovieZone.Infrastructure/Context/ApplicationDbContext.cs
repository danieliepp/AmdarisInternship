using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieZone.Domain;
using MovieZone.Domain.Configs;
using Microsoft.Extensions.Configuration;
using MovieZone.Domain.Models;
using MovieZone.Domain.Models.Configs;
using MovieZone.Domain.Models.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MovieZone.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken> 
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorBiography> ActorsBiography { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<MediaArt> MediaArts { get; set; }
        public DbSet<GenreMovie> GenreMovies { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

/*        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ActorConfig());
            modelBuilder.ApplyConfiguration(new ActorBiographyConfig());
            modelBuilder.ApplyConfiguration(new MovieConfig());
            modelBuilder.ApplyConfiguration(new GenreMovieConfig());
            modelBuilder.ApplyConfiguration(new ActorMovieConfig());
            
            ApplyIdentityMapConfiguration(modelBuilder);
        }

        private void ApplyIdentityMapConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users", Constants.AuthSchema);
            modelBuilder.Entity<UserClaim>().ToTable("UserClaims", Constants.AuthSchema);
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins", Constants.AuthSchema);
            modelBuilder.Entity<UserToken>().ToTable("UserRoles", Constants.AuthSchema);
            modelBuilder.Entity<Role>().ToTable("Roles", Constants.AuthSchema);
            modelBuilder.Entity<RoleClaim>().ToTable("RoleClaims", Constants.AuthSchema);
            modelBuilder.Entity<UserRole>().ToTable("UserRole", Constants.AuthSchema);
        }
    }
}
