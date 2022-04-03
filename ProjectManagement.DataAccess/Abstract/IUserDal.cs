using ProjectManagement.Core.DataAccess.Abstract;
using ProjectManagement.Entities.Concrete;
using ProjectManagement.Entities.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<UserRoleDto> GetRoles(int userId);
    }
}
