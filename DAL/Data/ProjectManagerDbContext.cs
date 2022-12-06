using Microsoft.EntityFrameworkCore;
using ProjectManager.DAL.Models.Entities;

namespace ProjectManager.DAL.Data
{
    public class ProjectManagerDbContext: DbContext //DbContext for this project
    {
        public ProjectManagerDbContext(DbContextOptions options): base(options) 
        {     
        }

        public DbSet<Project> Projects {get;set;}//Projects
        public DbSet<Models.Entities.Task> Tasks {get;set;}//Tasks
    }
}