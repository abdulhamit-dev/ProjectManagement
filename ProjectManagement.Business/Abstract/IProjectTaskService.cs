using ProjectManagement.Core.Utilities.Result;
using ProjectManagement.Entities.Concrete;
using ProjectManagement.Entities.Dtos.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Business.Abstract
{
    public interface IProjectTaskService
    {
        IDataResult<List<ProjectTask>> GetAll();
        IDataResult<List<ProjectTasksDto>> GetProjectTasks(int projectId);
        IDataResult<ProjectTask> GetById(int id);
        IResult Add(ProjectTask projectTask);
        IResult Update(ProjectTask projectTask);
        IResult Delete(int id);

    }
}
