using ProjectManagement.Core.Utilities.Result;
using ProjectManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Business.Abstract
{
    public interface ISubTaskService
    {
        IDataResult<List<SubTask>> GetAll();
        IDataResult<SubTask> GetById(int id);
        IResult Add(SubTask subTask);
        IResult Update(SubTask subTask);
        IResult Delete(int id);
    }
}
