using System.Collections;
using ProjectManager.BAL.Interfaces;
using ProjectManager.DAL.Models.Entities;
using ProjectManager.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace ProjectManager.BAL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ProjectManagerDbContext projectManagerDbContext;
        public ProjectService(ProjectManagerDbContext projectManagerDbContext)
        {
            this.projectManagerDbContext = projectManagerDbContext;
        }

        public async System.Threading.Tasks.Task AddProject(Project project)
        {
            await projectManagerDbContext.Projects.AddAsync(project);
            await projectManagerDbContext.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteProject(Guid projectID)
        {
            var project = await projectManagerDbContext.Projects.FindAsync(projectID);
            if(project == null)
            {
                throw new KeyNotFoundException();
            }
            projectManagerDbContext.Projects.Remove(project);
            await projectManagerDbContext.SaveChangesAsync();
        }

        public async Task<IList> GetAllProjects()
        {
            return await projectManagerDbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetProjectById(Guid projectID)
        {
            var project = await projectManagerDbContext.Projects.FindAsync(projectID);
            if(project == null)
            {
                throw new KeyNotFoundException();
            }
            return project;
        }

        public async System.Threading.Tasks.Task<IList> GetProjectTasksById(Guid projectID)
        {// this method is getting all tasks of this project
            var allTasks = await projectManagerDbContext.Tasks.ToListAsync();
            var projectTasks = new List<DAL.Models.Entities.Task>();
            foreach (var item in allTasks){
                if(item.ProjectId == projectID)
                    projectTasks.Add(item);
            }
            return projectTasks;
        }

        public async Task<Project> UpdateProject(Guid id, Project updatedProject)
        {
            var existingProject = await projectManagerDbContext.Projects.FindAsync(id);
            if( existingProject == null)
            {
                throw new KeyNotFoundException();
            }
            if(updatedProject.ProjectStatus == "Completed") 
            {//If Project is completed it means that "now" is completion date of this project
                existingProject.ProjectCompletionDate = DateTime.UtcNow;
            }
            existingProject.ProjectName = updatedProject.ProjectName;
            existingProject.ProjectStartDate = updatedProject.ProjectStartDate;
            existingProject.ProjectCompletionDate = updatedProject.ProjectCompletionDate;
            existingProject.ProjectStatus = updatedProject.ProjectStatus;
            existingProject.ProjectPriority = updatedProject.ProjectPriority;
            await projectManagerDbContext.SaveChangesAsync();
            return existingProject;
        }
    }
}