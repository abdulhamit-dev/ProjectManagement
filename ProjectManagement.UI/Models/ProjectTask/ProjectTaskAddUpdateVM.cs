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
        public List<UserVM> userVMs { get; set; }

        public ProjectTaskAddUpdateVM()
        {
            userVMs = new List<UserVM>();
            userVMs.Add(new UserVM() { Id=1,UserName="Admin"});
            userVMs.Add(new UserVM() { Id=2,UserName ="User 1"});
            userVMs.Add(new UserVM() { Id=3,UserName ="User 2"});
        }
    }
}
