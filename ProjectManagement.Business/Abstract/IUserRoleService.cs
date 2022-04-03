using ProjectManagement.Core.Utilities.Result;
using ProjectManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Business.Abstract
{
    public interface IUserRoleService
    {
        IDataResult<List<UserRole>> GetAll();
        IDataResult<UserRole> GetById(int id);
        IResult Add(UserRole userRole);
        IResult Update(UserRole userRole);
        IResult Delete(int id);
    }
}
