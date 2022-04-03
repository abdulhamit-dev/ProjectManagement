using ProjectManagement.Core.Utilities.Result;
using ProjectManagement.Entities.Concrete;
using ProjectManagement.Entities.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(int id);
        IDataResult<User> GetByName(string userName);
        IDataResult<List<UserRoleDto>> GetClaim(int userId);
    }
}
