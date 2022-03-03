using System;
using System.Threading.Tasks;
using DotnetTodoApiLab.Application.DTOs.Task;

namespace DotnetTodoApiLab.Application.Interfaces
{
    public interface ITaskService
    {
        public Task<TaskDTO> GetTaskAsync(Guid id);

        public Task<TaskDTO> CreateTaskAsync(TaskDTO hero);

        public Task<bool> DeleteTaskAsync(Guid id);
    }
}
