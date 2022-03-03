using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DotnetTodoApiLab.Api.Extensions;
using DotnetTodoApiLab.Application.Interfaces;
using DotnetTodoApiLab.Application.Services;
using DotnetTodoApiLab.Domain.Repositories;
using DotnetTodoApiLab.Infrastructure.Repositories;

namespace DotnetTodoApiLab.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Extension method for less clutter in startup
            services.AddApplicationDbContext(Configuration);

            //DI Services and Repos
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskService, TaskService>();

            // WebApi Configuration
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); // for enum as strings
            });

            // AutoMapper settings
            services.AddAutoMapperSetup();

            // HttpContext for log enrichment 
            services.AddHttpContextAccessor();

            // Swagger settings
            services.AddApiDoc();
            // GZip compression
            services.AddCompression();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseCustomSerilogRequestLogging();
            app.UseRouting();
            app.UseApiDoc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHttpsRedirection();
            
            app.UseResponseCompression();
        }
    }
}
