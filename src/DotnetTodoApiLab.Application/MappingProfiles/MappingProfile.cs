using AutoMapper;
using DotnetTodoApiLab.Application.DTOs.Task;
using DotnetTodoApiLab.Domain.Entities;

namespace DotnetTodoApiLab.Application.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Task, TaskDTO>().ReverseMap();
        }
    }
}
