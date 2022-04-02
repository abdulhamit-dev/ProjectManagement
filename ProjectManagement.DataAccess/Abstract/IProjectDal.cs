using ProjectManagement.Core.DataAccess.Abstract;
using ProjectManagement.Entities.Concrete;

namespace ProjectManagement.DataAccess.Abstract
{
    public interface IProjectDal : IEntityRepository<Project>
    {
    }
}
