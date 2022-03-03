using System;
using AutoMapper;
using DotnetTodoApiLab.Application.MappingProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetTodoApiLab.Api.Extensions
{
    public static class AutoMapperExtension
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
