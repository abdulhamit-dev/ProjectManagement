using ProjectManagement.Business.Abstract;
using ProjectManagement.Business.Constant;
using ProjectManagement.Business.ValidationRules.FluentValidation;
using ProjectManagement.Core.Aspects.Autofac.Validation;
using ProjectManagement.Core.Utilities.Result;
using ProjectManagement.DataAccess.Abstract;
using ProjectManagement.Entities.Concrete;
using ProjectManagement.Entities.Dtos.User;

namespace ProjectManagement.Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(MessageReturns.Add);
        }

        public IResult Delete(int id)
        {
            var user = _userDal.Get(x => x.Id == id);
            if (user is null)
                return new ErrorResult(MessageReturns.NotFound);
            else
            {
                _userDal.Delete(user);
                return new SuccessResult(MessageReturns.Delete);
            }
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int id)
        {
            var user = _userDal.Get(x => x.Id == id);
            if (user is null)
                return new ErrorDataResult<User>(null, MessageReturns.NotFound);

            return new SuccessDataResult<User>(user);
        }

        public IDataResult<User> GetByName(string userName)
        {
            return new SuccessDataResult<User>(_userDal.Get(x => x.UserName == userName));
        }

        public IDataResult<List<UserRoleDto>> GetClaim(int userId)
        {
            return new SuccessDataResult<List<UserRoleDto>>(_userDal.GetRoles(userId));
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(MessageReturns.Update);
        }
    }
}
