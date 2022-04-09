using ProjectManagement.UI.Models.User;

namespace ProjectManagement.UI.Models.ProjectTask
{
    public class ProjectTaskAddUpdateVM
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public DateTime DueDate { get; set; }= DateTime.Now;
        public bool IsComplate { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public List<UserVM> userVMs { get; set; } = new List<UserVM>();
    }
}
