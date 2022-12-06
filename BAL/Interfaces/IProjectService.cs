using System.Collections;
using ProjectManager.DAL.Models.Entities;

namespace ProjectManager.BAL.Interfaces
{
    public interface IProjectService
    {
        Task<IList> GetAllProjects();
        System.Threading.Tasks.Task<Project> GetProjectById(Guid projectID);
        System.Threading.Tasks.Task AddProject(Project project);
        System.Threading.Tasks.Task<Project> UpdateProject(Guid id,Project project);
        System.Threading.Tasks.Task DeleteProject(Guid projectID);
        System.Threading.Tasks.Task<IList> GetProjectTasksById(Guid projectID);
    }
}