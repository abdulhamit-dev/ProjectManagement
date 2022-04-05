using ProjectManagement.UI.Models.Project;
using ProjectManagement.UI.Models.Team;

namespace ProjectManagement.UI.Models.Home
{
    public class HomeVM
    {
        public List<ProjectVM> projectVMs { get; set; }=new List<ProjectVM>();
        public List<TeamVM> teamVMs { get; set; }=new List<TeamVM>();
    }
}
