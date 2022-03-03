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
        public async Task<ActionResult<IList<TaskDTO>>> GetTasks()
        {
            // TODO IN LAB
            throw new NotImplementedException();
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

            //var newHero = await _heroService.CreateHero(dto);
            //return CreatedAtAction(nameof(GetHeroById), new { id = newHero.Id }, newHero);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<TaskDTO>> Update(Guid id, [FromBody] TaskDTO taskDTO)
        {
            // TODO IN LAB
            throw new NotImplementedException();
        }


        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            // TODO IN LAB
            throw new NotImplementedException();
        }

    }
}
