using System.ComponentModel.DataAnnotations;

namespace ProjectManager.DAL.Models.Entities{
    public class Task{
        public Guid TaskId {get;set;}
        [Required]
        public string TaskName{get;set;}
        [Required]
        public string TaskDescription {get;set;}
        public string TaskStatus{get;set;}
        [Required]
        public int TaskPriority{get;set;}
        public Guid ProjectId{get;set;}

        public Task()
        {
            TaskStatus = "ToDo";
        }
    }
}