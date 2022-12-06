using System.ComponentModel.DataAnnotations;

namespace ProjectManager.DAL.Models.Entities{
    public class Project{ //Project model
        public Guid ProjectId {get;set;}
        [Required]
        public string ProjectName {get;set;}
        public DateTime ProjectStartDate {get;set;}
        public DateTime ProjectCompletionDate{get;set;}
        public string ProjectStatus{get;set;}
        [Required]
        public int ProjectPriority{get;set;}
        
        public Project(){
            ProjectStartDate = DateTime.UtcNow; //Starting date is date when project instance was created
            ProjectId = Guid.NewGuid();//setting guid
            ProjectStatus = "NotStarted";//by default status if NotStarted
        }
    }
}