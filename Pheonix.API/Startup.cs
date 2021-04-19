using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pheonix.API.DependencyInjection;
using Pheonix.Infra.Context;

namespace Pheonix.API
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
            services.AddControllers();
            services
                .AddServicesInjection()
                .AddRepositoriesInjection();

            AddDbContextInMemory(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pheonix.Api", Version = "v1" });
            });
        }        

        private void AddDbContext(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("PheonixCn");
            services.AddDbContext<PheonixContext>(options => options.UseSqlServer(connectionString));
        }

        private void AddDbContextInMemory(IServiceCollection services)
        {
            services.AddDbContext<PheonixContext>(options => options.UseInMemoryDatabase("Pheonix"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pheonix.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
