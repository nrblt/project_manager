using Microsoft.AspNetCore.Mvc;
using ProjectManager.DAL.Data;
using ProjectManager.BAL.Interfaces;

namespace ProjectManager.AddControllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController: Controller
    {
        private readonly ITaskService taskService;
        public TaskController(ProjectManagerDbContext projectManagerDbContext, ITaskService taskService)
        {
            this.taskService = taskService;
        }    

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            return Ok(await taskService.GetAllTasks());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [ActionName("GetTaskById")]
        public async Task<IActionResult> GetTaskById([FromRoute]Guid id)
        {
            return Ok(await taskService.GetTaskById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(DAL.Models.Entities.Task task)
        {
            await taskService.AddTask(task);
            return CreatedAtAction(nameof(GetTaskById), new {id = task.TaskId}, task);
        }

        [HttpPut]
        [Route("{id:Guid}")]//we can add task to project using this route
        public async Task<IActionResult> UpdateTask([FromRoute]Guid id, [FromBody] DAL.Models.Entities.Task updatedTask)
        {
            return Ok(await taskService.UpdateTask(id, updatedTask));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteProject([FromRoute]Guid id)
        {
            await taskService.DeleteTask(id);
            return Ok();
        }
        
        [HttpPut]
        [Route("remove_from_project/{id:Guid}")]//this route will delete task from project
        public async Task<IActionResult> RemoveFromProject([FromRoute]Guid id)
        {
            return Ok(await taskService.RemoveFromProject(id));
        }
    }
}