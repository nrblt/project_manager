using Microsoft.AspNetCore.Mvc;
using ProjectManager.DAL.Data;
using ProjectManager.DAL.Models.Entities;
using ProjectManager.BAL.Interfaces;

namespace ProjectManager.Controllers
{
    [ApiController]
    [Route("api/projects")]

    public class ProjectController: Controller
    {
        private readonly IProjectService projectService;
        public ProjectController(ProjectManagerDbContext projectManagerDbContext,
        IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            return Ok(await projectService.GetAllProjects());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [ActionName("GetProjectById")]
        public async Task<IActionResult> GetProjectById([FromRoute]Guid id)
        {
            return Ok(await projectService.GetProjectById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(Project project)
        {
            await projectService.AddProject(project);
            return CreatedAtAction(nameof(GetProjectById), new {id = project.ProjectId}, project);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateProject([FromRoute]Guid id, [FromBody] Project updatedProject)
        {
            return Ok(await projectService.UpdateProject(id, updatedProject));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteProject([FromRoute]Guid id)
        {
            await projectService.DeleteProject(id);
            return Ok();
        }

        [HttpGet]
        [Route("project_tasks/{id:Guid}")]//Getting all tasks of this project
        public async Task<IActionResult> GetProjectTasksById([FromRoute]Guid id){
            return Ok(await projectService.GetProjectTasksById(id));
        }
    }
}