using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using DotnetTodoApiLab.Application.DTOs.Task;

namespace DotnetTodoApiLab.Application.Interfaces
{
    public interface ITaskService
    {
        public Task<TaskDTO> GetTaskAsync(Guid id);

        public Task<TaskDTO> UpdateTaskAsync(Guid id, TaskDTO task);

        public IList<TaskDTO> GetTaskList();

        public Task<TaskDTO> CreateTaskAsync(TaskDTO hero);

        public Task<bool> DeleteTaskAsync(Guid id);
    }
}
