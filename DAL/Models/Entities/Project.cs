using System.ComponentModel.DataAnnotations;

namespace ProjectManager.DAL.Models.Entities{
    public class Project{
        public Guid ProjectId {get;set;}
        [Required]
        public string ProjectName {get;set;}
        public DateTime ProjectStartDate {get;set;}
        public DateTime ProjectCompletionDate{get;set;}
        public string ProjectStatus{get;set;}
        [Required]
        public int ProjectPriority{get;set;}
        
        public Project(){
            ProjectStartDate = DateTime.UtcNow;
            ProjectId = Guid.NewGuid();
            ProjectStatus = "NotStarted";
        }
    }
}