using Microsoft.EntityFrameworkCore;
using ProjectManager.DAL.Models.Entities;

namespace ProjectManager.DAL.Data
{
    public class ProjectManagerDbContext: DbContext
    {
        public ProjectManagerDbContext(DbContextOptions options): base(options) 
        {     
        }

        public DbSet<Project> Projects {get;set;}
        public DbSet<Models.Entities.Task> Tasks {get;set;}
    }
}