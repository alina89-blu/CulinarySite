using CulinarySite.Api.AutoMapperProfiles;
using CulinarySite.Api.Infrastructure.Extensions;
using CulinarySite.Bll.AutoMapperProfiles;
using CulinarySite.Bll.Interfaces;
using CulinarySite.Bll.Services;
using CulinarySite.Dal;
using CulinarySite.Dal.Extensions;
using CulinarySite.Dal.Interfaces;
using CulinarySite.Dal.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CulinarySite.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = "Server=DESKTOP-N5BQGM7\\SQLEXPRESS;Database=culinarysitedb;Trusted_Connection=True;";

            services.AddDbContext<CulinarySiteDbContext>(options => options
            .UseSqlServer(connectionString))
            .AddIdentity()
            .AddJwtAuthentication(services.GetApplicationSettings(this.Configuration));
           
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

