using CulinaryApi.AutoMapperProfiles;
using CulinaryApi.Infrastructure.Extensions;
using Database.Entities;
using Database.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Repositories;
using ServiceLayer;
using ServiceLayer.AutoMapperProfiles;
using System.Text;

namespace CulinaryApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
          
            string connectionString = "Server=DESKTOP-N5BQGM7\\SQLEXPRESS;Database=culinarysitedb;Trusted_Connection=True;";                        

            services.AddDbContext<CulinarySiteDbContext>(options => options.UseSqlServer(connectionString));

            //Token

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

            })
               .AddEntityFrameworkStores<CulinarySiteDbContext>();

            var applicationSettingsConfiguration = this.Configuration.GetSection("ApplicationSettings");
            services.Configure<AppSettings>(applicationSettingsConfiguration);

            var appSettings = applicationSettingsConfiguration.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   ValidateIssuer = false,
                   ValidateAudience = false
               };
           });

            //Token

            services.AddControllers()
           .AddNewtonsoftJson(options =>
           options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);                    

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "CulinarySiteApp/dist";
            });
           

            services.AddAutoMapper(typeof(DtoProfile), typeof(EntityProfile));

            services.AddScoped(typeof(IWriteGenericRepository<>), typeof(EFWriteGenericRepository<>));
            services.AddScoped(typeof(IReadOnlyGenericRepository<>), typeof(EFReadOnlyGenericRepository<>));
            services.AddScoped(typeof(IAddressService), typeof(AddressService));
            services.AddScoped(typeof(IAuthorService), typeof(AuthorService));
            services.AddScoped(typeof(IBookService), typeof(BookService));
            services.AddScoped(typeof(ICommentService), typeof(CommentService));
            services.AddScoped(typeof(ICookingStageService), typeof(CookingStageService));
            services.AddScoped(typeof(ICulinaryChannelService), typeof(CulinaryChannelService));
            services.AddScoped(typeof(IDishService), typeof(DishService));
            services.AddScoped(typeof(IEpisodeService), typeof(EpisodeService));
            services.AddScoped(typeof(IImageService), typeof(ImageService));
            services.AddScoped(typeof(IIngredientService), typeof(IngredientService));
            services.AddScoped(typeof(IOrganicMatterService), typeof(OrganicMatterService));
            services.AddScoped(typeof(IRecipeService), typeof(RecipeService));
            services.AddScoped(typeof(IRestaurantService), typeof(RestaurantService));
            services.AddScoped(typeof(ISubscriberService), typeof(SubscriberService));
            services.AddScoped(typeof(ITagService), typeof(TagService));
            services.AddScoped(typeof(ITelephoneService), typeof(TelephoneService));
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
            }
          
            app.UseExceptionHandling();

            app.UseStaticFiles();

            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }            

            app.UseRouting();

            //Token

            app.UseCors(options => options
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());

            app.UseAuthentication();
            app.UseAuthorization();

            //Token

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();             
            });
          
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "CulinarySiteApp";

                if (env.IsDevelopment())
                {                    
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });

            app.ApplyMigrations();


        }
    }
}

