using DotnetTodoApiLab.Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetTodoApiLab.Api.Extensions
{
    public static class DatabaseExtension
    {
        public static void AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("DotNetTodoApiLabDatabase"));
        }
    }
}
