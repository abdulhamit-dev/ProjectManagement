using ProjectManagement.Core.DataAccess.Concrete.EntityFramework;
using ProjectManagement.DataAccess.Abstract;
using ProjectManagement.DataAccess.Concrete.EntityFramework.Contexts;
using ProjectManagement.Entities.Concrete;
using ProjectManagement.Entities.Dtos.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfProjectTaskDal : EfEntityRepositoryBase<ProjectTask, ProjectManagementContext>, IProjectTaskDal
    {
        public List<ProjectTasksDto> GetProjectTasks(int projectId)
        {
            using var context = new ProjectManagementContext();
            var result = from project in context.Projects
                         join task in context.ProjectTasks on project.Id equals task.ProjectId
                         join user in context.Users on task.UserId equals user.Id
                         where project.Id == projectId
                         select new ProjectTasksDto
                         {
                             DueDate = task.DueDate,
                             IsComplate = task.IsComplate,
                             TaskDescription = task.Description,
                             ProjectName = project.Name,
                             TaskId = task.Id,
                             UserName = user.UserName,
                         };
            return result.ToList();
        }

    }
}
