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
    public interface IProjectService
    {
        IDataResult<List<Project>> GetAll();
        IDataResult<Project> GetById(int id);
        IResult Add(Project project);
        IResult Update(Project project);
        IResult Delete(int id);
    }
}
