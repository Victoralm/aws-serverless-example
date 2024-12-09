using CoreWebApi.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CoreWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        ServiceProvider _serviceProvider; // To enable controllers properly

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDol2RealRepository, Dol2RealRepository>();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            _serviceProvider = services.BuildServiceProvider(); // To enable controllers properly
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    //await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
                    await context.Response.WriteAsync($"R$ {Scrappy.RealCurated()}");
                });
            });
        }
    }
}