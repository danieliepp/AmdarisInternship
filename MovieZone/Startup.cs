using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MovieZone.API.Exeptions;
using MovieZone.API.Middleware;
using MovieZone.API.Profiles;
using MovieZone.API.Services.Implementations;
using MovieZone.API.Services.Implementations.Auth;
using MovieZone.API.Services.Interfaces;
using MovieZone.API.Services.Interfaces.Auth;
using MovieZone.Domain;
using MovieZone.Domain.Models;
using MovieZone.Infrastructure;
using MovieZone.Infrastructure.Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using MovieZone.Domain.Models.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

namespace MovieZone
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAzureClients(builder =>
            {
                builder.AddBlobServiceClient(Configuration.GetSection("Storage:ConnectionString").Value);
            });

            services.AddDbContext<ApplicationDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(jwt =>
                {
                    var key = Encoding.ASCII.GetBytes(Configuration["AppSettings:Secret"]);

                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true, // this will validate the 3rd part of the jwt token using the secret that we added in the appsettings and verify we have generated the jwt token
                    IssuerSigningKey = new SymmetricSecurityKey(key), // Add the secret key to our Jwt encryption
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = false,
                    ValidateLifetime = true
                };
            });

            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllers();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddHttpClient();
            services.AddScoped<IMoviesService, MoviesService>();
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<IGenresService, GenresService>();
            services.AddScoped<IStudioService, StudioService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IActorsService, ActorsService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<ICountriesService, CountriesService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            ConfigureSwagger(services);

            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MovieProfile());
                cfg.AddProfile(new CategoryProfile());
                cfg.AddProfile(new GenreProfile());
                cfg.AddProfile(new DefaultProfile());
                cfg.AddProfile(new UserProfile());
                cfg.AddProfile(new ActorProfile());
            }).CreateMapper());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "PlaceInfo Services"));
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseExceptionMiddleware();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }


        private void ConfigureSwagger(IServiceCollection services)
        {
            var info = new OpenApiInfo()
            {
                Version = "v1",
                Title = "Swagger Demo API",
                Description = "Swagger Demo API Description"
            };

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", info);
            });
        }
    }
}
