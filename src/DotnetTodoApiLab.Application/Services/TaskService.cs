using System;
using System.Threading.Tasks;
using AutoMapper;
using DotnetTodoApiLab.Application.DTOs.Task;
using DotnetTodoApiLab.Application.Interfaces;
using DotnetTodoApiLab.Domain.Repositories;
using System.Linq;
using System.Collections.Generic;

namespace DotnetTodoApiLab.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskDTO> GetTaskAsync(Guid id)
        {
            var task = await _taskRepository.GetById(id);
            return _mapper.Map<TaskDTO>(task);
        }

        public IList<TaskDTO> GetTaskList()
        {
            var task = _taskRepository.GetAll().ToList();
            return _mapper.Map<IList<TaskDTO>>(task);
        }

        public async Task<TaskDTO> UpdateTaskAsync(Guid id, TaskDTO task)
        {
            task.Id = id;
            var result = _taskRepository.Update(_mapper.Map<Domain.Entities.Task>(task));
            await _taskRepository.SaveChangesAsync();
            return _mapper.Map<TaskDTO>(result);
        }

        public async Task<TaskDTO> CreateTaskAsync(TaskDTO task)
        {
            var result = _taskRepository.Create(_mapper.Map<Domain.Entities.Task>(task));
            await _taskRepository.SaveChangesAsync();
            return _mapper.Map<TaskDTO>(result);
        }

        public async Task<bool> DeleteTaskAsync(Guid id)
        {
            await _taskRepository.Delete(id);
            int result = await _taskRepository.SaveChangesAsync();
            if (result == 0){
                return false;
            }
            return true;
        }

    }
}
