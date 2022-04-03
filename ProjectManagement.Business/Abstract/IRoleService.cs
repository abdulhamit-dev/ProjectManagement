using ProjectManagement.Core.Utilities.Result;
using ProjectManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Business.Abstract
{
    public interface IRoleService
    {
        IDataResult<List<Role>> GetAll();
        IDataResult<Role> GetById(int id);
        IResult Add(Role role);
        IResult Update(Role role);
        IResult Delete(int id);
    }
}
