using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Futurity.Persistence.Contexts;

namespace Futurity.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Futurity.Api", Version = "v1" });
            });

            services.AddHealthChecks();

            services.AddDbContext<FuturityMSSQLContext>(options =>
            {
                if (_environment.IsEnvironment("Test"))
                {
                    options.UseInMemoryDatabase("TestDatabase");
                }
                else
                {
                    options.UseSqlServer(_configuration.GetConnectionString("MainDataContext"));
                }
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<FuturityMSSQLContext>();

                if (env.IsEnvironment("Test"))
                {
                    context.Database.EnsureDeleted();
                }
                else
                {
                    context.Database.Migrate();
                }
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Futurity.Api v1"));

            app.UseHealthChecks("/healthcheck");

            var rewriteOptions = new RewriteOptions();
            rewriteOptions.AddRedirect("^$", "swagger");
            app.UseRewriter(rewriteOptions);

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
