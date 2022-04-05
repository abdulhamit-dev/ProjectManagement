namespace ProjectManagement.UI.Models.Project
{
    public class ProjectVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TeamId { get; set; }
        public bool IsActive { get; set; }
    }
}
