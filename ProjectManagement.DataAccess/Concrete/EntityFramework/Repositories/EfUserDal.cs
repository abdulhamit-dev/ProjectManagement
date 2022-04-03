using ProjectManagement.Core.DataAccess.Concrete.EntityFramework;
using ProjectManagement.DataAccess.Abstract;
using ProjectManagement.DataAccess.Concrete.EntityFramework.Contexts;
using ProjectManagement.Entities.Concrete;
using ProjectManagement.Entities.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfUserDal : EfEntityRepositoryBase<User, ProjectManagementContext>, IUserDal
    {
        public List<UserRoleDto> GetRoles(int userId)
        {
            using var context = new ProjectManagementContext();
            var result = from roles in context.Roles
                         join userRoles in context.UserRoles
                             on roles.Id equals userRoles.RoleId
                         where userRoles.UserId == userId
                         select new UserRoleDto { RoleId = roles.Id, Name = roles.Name };
            return result.ToList();
        }
    }
}
