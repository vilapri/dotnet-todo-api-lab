using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DotnetTodoApiLab.Application.DTOs.Task;
using DotnetTodoApiLab.Application.Interfaces;

namespace DotnetTodoApiLab.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<TaskDTO>), StatusCodes.Status200OK)]
        public ActionResult<IList<TaskDTO>> GetTasks()
        {
            var taskList = _taskService.GetTaskList();

            return Ok(taskList);
        }


        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(TaskDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<TaskDTO>> GetTaskById(Guid id)
        {
            var task = await _taskService.GetTaskAsync(id);

            return task == null ? NotFound() : Ok(task);
        }


        [HttpPost]
        public async Task<ActionResult<TaskDTO>> Create([FromBody] TaskDTO taskDTO)
        {
            var task = await _taskService.CreateTaskAsync(taskDTO);
            return CreatedAtAction(nameof(Create), task);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<TaskDTO>> Update(Guid id, [FromBody] TaskDTO taskDTO)
        {
            var task = await _taskService.UpdateTaskAsync(id, taskDTO);
            return Ok(task);
        }


        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            bool result = await _taskService.DeleteTaskAsync(id);
            if (result == true){
                return Ok();
            }
            return BadRequest();
        }

    }
}
