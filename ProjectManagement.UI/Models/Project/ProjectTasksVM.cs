namespace ProjectManagement.UI.Models.Project
{
    public class ProjectTasksVM
    {
        public int TaskId { get; set; }
        public string ProjectName { get; set; }
        public string TaskDescription { get; set; }
        public string UserName { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsComplate { get; set; }
    }
}
