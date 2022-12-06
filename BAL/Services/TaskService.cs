using System.Collections;
using ProjectManager.BAL.Interfaces;
using ProjectManager.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace ProjectManager.BAL.Services
{
    public class TaskService : ITaskService
    {
        private readonly ProjectManagerDbContext projectManagerDbContext;
        public TaskService(ProjectManagerDbContext projectManagerDbContext)
        {
            this.projectManagerDbContext = projectManagerDbContext;
        }

        public async System.Threading.Tasks.Task AddTask(DAL.Models.Entities.Task task)
        {
            await projectManagerDbContext.Tasks.AddAsync(task);
            await projectManagerDbContext.SaveChangesAsync();        
        }
        public async System.Threading.Tasks.Task DeleteTask(Guid taskID)
        {
            var task = await projectManagerDbContext.Tasks.FindAsync(taskID);
            if(task == null)
            {
                throw new KeyNotFoundException();
            }
            projectManagerDbContext.Tasks.Remove(task);
            await projectManagerDbContext.SaveChangesAsync();       
        }
        public async Task<IList> GetAllTasks()
        {
            return await projectManagerDbContext.Tasks.ToListAsync();
        }

        public async Task<DAL.Models.Entities.Task> GetTaskById(Guid taskID)
        {
            var task = await projectManagerDbContext.Tasks.FindAsync(taskID);
            if(task == null)
            {
                throw new KeyNotFoundException();
            }
            return task;        
        }
        public async Task<DAL.Models.Entities.Task> RemoveFromProject(Guid taskID)
        {
            var existingTask = await projectManagerDbContext.Tasks.FindAsync(taskID);
            if( existingTask == null)
            {
                throw new KeyNotFoundException();
            }
            existingTask.ProjectId = Guid.Empty;
            await projectManagerDbContext.SaveChangesAsync();
            return existingTask;
        }

        public async Task<DAL.Models.Entities.Task> UpdateTask(Guid id, DAL.Models.Entities.Task updatedTask)
        {
            var existingTask = await projectManagerDbContext.Tasks.FindAsync(id);
            if( existingTask == null)
            {
                throw new KeyNotFoundException();
            }
            existingTask.TaskName = updatedTask.TaskName;
            existingTask.TaskDescription = updatedTask.TaskDescription;
            existingTask.TaskPriority = updatedTask.TaskPriority;
            existingTask.TaskStatus = updatedTask.TaskStatus;
            existingTask.ProjectId = updatedTask.ProjectId;

            await projectManagerDbContext.SaveChangesAsync();        
            return existingTask;
        }
    }
}