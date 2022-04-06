using ProjectManagement.Core.DataAccess.Abstract;
using ProjectManagement.Entities.Concrete;
using ProjectManagement.Entities.Dtos.Project;

namespace ProjectManagement.DataAccess.Abstract
{
    public interface IProjectDal : IEntityRepository<Project>
    {
        public List<ProjectTasksDto> GetProjectTasks(int projectId);
    }
}
