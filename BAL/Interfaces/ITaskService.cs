using System.Collections;

namespace ProjectManager.BAL.Interfaces
{
    public interface ITaskService
    {
        Task<IList> GetAllTasks();
        System.Threading.Tasks.Task<DAL.Models.Entities.Task> GetTaskById(Guid taskID);
        System.Threading.Tasks.Task AddTask(DAL.Models.Entities.Task task);
        System.Threading.Tasks.Task<DAL.Models.Entities.Task> UpdateTask(Guid id , DAL.Models.Entities.Task updatedTask);
        System.Threading.Tasks.Task DeleteTask(Guid taskID);
        System.Threading.Tasks.Task<DAL.Models.Entities.Task> RemoveFromProject(Guid taskID);
    }
}