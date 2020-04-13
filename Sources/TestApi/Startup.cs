using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mmu.IdentityProvider.TestApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllers();
                });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAuthorization(
                options =>
                    options.AddPolicy(
                        "WritePolicy",
                        builder =>
                        {
                            builder.RequireScope("api.write");
                        }));

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(
                    options =>
                    {
                        options.Authority = "https://localhost:44339";
                        options.RequireHttpsMetadata = false;

                        options.ApiName = "CoolWebApi";
                    });
        }
    }
}