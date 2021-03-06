using ProjectManagement.UI.Models.Team;

namespace ProjectManagement.UI.Models.User
{
    public class UserVM
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int TeamId { get; set; }
        public bool IsActive { get; set; }
        
    }
}
