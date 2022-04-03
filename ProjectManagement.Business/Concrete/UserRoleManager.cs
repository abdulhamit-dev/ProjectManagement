using ProjectManagement.Business.Abstract;
using ProjectManagement.Business.Constant;
using ProjectManagement.Business.ValidationRules.FluentValidation;
using ProjectManagement.Core.Aspects.Autofac.Validation;
using ProjectManagement.Core.Utilities.Result;
using ProjectManagement.DataAccess.Abstract;
using ProjectManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Business.Concrete
{
    public class UserRoleManager : IUserRoleService
    {
        IUserRoleDal _userRoleDal;

        public UserRoleManager(IUserRoleDal userRoleDal)
        {
            _userRoleDal = userRoleDal;
        }
        [ValidationAspect(typeof(UserRoleValidator))]
        public IResult Add(UserRole userRole)
        {
            _userRoleDal.Add(userRole);
            return new SuccessResult(MessageReurns.Add);
        }

        public IResult Delete(int id)
        {
            var userRole = _userRoleDal.Get(x => x.Id == id);
            if (userRole is null)
                return new ErrorResult(MessageReurns.NotFound);
            else
            {
                _userRoleDal.Delete(userRole);
                return new SuccessResult(MessageReurns.Delete);
            }
        }

        public IDataResult<List<UserRole>> GetAll()
        {
            return new SuccessDataResult<List<UserRole>>(_userRoleDal.GetAll());
        }

        public IDataResult<UserRole> GetById(int id)
        {
            var userRole = _userRoleDal.Get(x => x.Id == id);
            if (userRole is null)
                return new ErrorDataResult<UserRole>(null, MessageReurns.NotFound);

            return new SuccessDataResult<UserRole>(userRole);
        }
        [ValidationAspect(typeof(UserRoleValidator))]
        public IResult Update(UserRole userRole)
        {
            _userRoleDal.Update(userRole);
            return new SuccessResult(MessageReurns.Update);
        }
    }
}
