using ProjectManagement.UI.Models.Team;

namespace ProjectManagement.UI.Models.Project
{
    public class ProjectAddUpdateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TeamId { get; set; }
        public bool IsActive { get; set; } = true;
        public List<TeamVM> TeamVMs { get; set; } = new List<TeamVM>();
    }
}
