using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SportsStore.Models;

namespace SportsStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddDbContext<ApplicationDbContext>(options => options. Options.U(Configuration["Data:SportStoreProducts:ConnectionString"]));
        }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            ConfigureCommonServices(services);
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(@"Data Source=App_Data\sportsStore.db"));
        }

        public void ConfigureStagingServices(IServiceCollection services)
        {
            ConfigureCommonServices(services);
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(@"Data Source=App_Data\sportsStore.db"));
        }

        private static void ConfigureCommonServices(IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ApplicationDbContext>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "",
                    pattern: "{category}/Page/{page}",
                    defaults: new { Controller = "Product", Action = "List" });

                endpoints.MapControllerRoute(
                    name: "pagination",
                    pattern: "Page{page}",
                    defaults: new { Controller = "Product", Action = "List" });

                endpoints.MapControllerRoute(
                    name: "",
                    pattern: "{category}",
                    defaults: new { Controller = "Product", Action = "List" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=List}/{id?}");
            });
            
            //SeedData.EnsurePopulated(app);
        }
    }
}
