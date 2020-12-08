using System.Linq;
using JsonApiDotNetCore.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MyApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add the Entity Framework Core DbContext like you normally would
            services.AddDbContext<AppDbContext>(options =>
            {
                // Use whatever provider you want, this is just an example
                options.UseSqlite("Data Source=my-api.db");
            });

            // Add JsonApiDotNetCore
            services.AddJsonApi<AppDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.People.Any())
            {
                context.People.Add(new Person
                {
                    Name = "John Doe"
                });
                context.SaveChanges();
            }
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseJsonApi();
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
