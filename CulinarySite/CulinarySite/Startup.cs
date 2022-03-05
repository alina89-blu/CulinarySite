using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositories;
using ServiceLayer;

namespace CulinarySite
{
    public class Startup
    {        
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=culinarysitedb;Trusted_Connection=True;";
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
            services.AddControllers()
           .AddNewtonsoftJson(options =>
           options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "CulinarySiteApp/dist";
            });
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
            services.AddScoped(typeof(IRecipeOrganicMatterService), typeof(RecipeOrganicMatterService));
            services.AddScoped(typeof(IRecipeService), typeof(RecipeService));
            services.AddScoped(typeof(IRecipeIngredientService), typeof(RecipeIngredientService));
            services.AddScoped(typeof(IRestaurantService), typeof(RestaurantService));
            services.AddScoped(typeof(ISubscriberService), typeof(SubscriberService));
            services.AddScoped(typeof(ITagService), typeof(TagService));
            services.AddScoped(typeof(ITelephoneService), typeof(TelephoneService));
            
            //

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "CulinarySiteApp";

                if (env.IsDevelopment())
                {
                    //spa.UseAngularCliServer(npmScript: "start");
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });
        }
    }
}
