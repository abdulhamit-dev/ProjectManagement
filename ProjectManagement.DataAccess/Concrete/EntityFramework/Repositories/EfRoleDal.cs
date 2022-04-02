using ProjectManagement.Core.DataAccess.Concrete.EntityFramework;
using ProjectManagement.DataAccess.Abstract;
using ProjectManagement.DataAccess.Concrete.EntityFramework.Contexts;
using ProjectManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfRoleDal:EfEntityRepositoryBase<Role, ProjectManagementContext>, IRoleDal
    {
    }
}
