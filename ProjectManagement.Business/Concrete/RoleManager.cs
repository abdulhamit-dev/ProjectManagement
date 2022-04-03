using ProjectManagement.Business.Abstract;
using ProjectManagement.Business.Constant;
using ProjectManagement.Business.ValidationRules.FluentValidation;
using ProjectManagement.Core.Aspects.Autofac.Validation;
using ProjectManagement.Core.Utilities.Result;
using ProjectManagement.DataAccess.Abstract;
using ProjectManagement.Entities.Concrete;

namespace ProjectManagement.Business.Concrete
{
    public class RoleManager : IRoleService
    {
        IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        [ValidationAspect(typeof(RoleValidator))]
        public IResult Add(Role role)
        {
            _roleDal.Add(role);
            return new SuccessResult(MessageReturns.Add);
        }

        public IResult Delete(int id)
        {
            var role = _roleDal.Get(x => x.Id == id);
            if (role is null)
                return new ErrorResult(MessageReturns.NotFound);
            else
            {
                _roleDal.Delete(role);
                return new SuccessResult(MessageReturns.Delete);
            }
        }

        public IDataResult<List<Role>> GetAll()
        {
            return new SuccessDataResult<List<Role>>(_roleDal.GetAll());
        }

        public IDataResult<Role> GetById(int id)
        {
            var role = _roleDal.Get(x => x.Id == id);
            if (role is null)
                return new ErrorDataResult<Role>(null, MessageReturns.NotFound);

            return new SuccessDataResult<Role>(role);
        }
        [ValidationAspect(typeof(RoleValidator))]
        public IResult Update(Role role)
        {
            _roleDal.Update(role);
            return new SuccessResult(MessageReturns.Update);
        }
    }
}
