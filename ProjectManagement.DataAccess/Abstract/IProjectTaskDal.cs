using ProjectManagement.Core.DataAccess.Abstract;
using ProjectManagement.Entities.Concrete;
using ProjectManagement.Entities.Dtos.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.DataAccess.Abstract
{
    public interface IProjectTaskDal: IEntityRepository<ProjectTask>
    {
        List<ProjectTasksDto> GetProjectTasks(int projectId);
        List<ProjectTasksDto> GetUserTasks(int userId);
    }
}
