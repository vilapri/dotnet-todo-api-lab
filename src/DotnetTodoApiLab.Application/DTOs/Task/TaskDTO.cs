using System;

namespace DotnetTodoApiLab.Application.DTOs.Task
{
    public class TaskDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
