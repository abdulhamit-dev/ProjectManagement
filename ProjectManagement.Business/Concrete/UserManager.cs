using ProjectManagement.Business.Abstract;
using ProjectManagement.Business.Constant;
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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(MessageReurns.Add);
        }

        public IResult Delete(int id)
        {
            var user = _userDal.Get(x => x.Id == id);
            if (user is null)
                return new ErrorResult(MessageReurns.NotFound);
            else
            {
                _userDal.Delete(user);
                return new SuccessResult(MessageReurns.Delete);
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
                return new ErrorDataResult<User>(null, MessageReurns.NotFound);

            return new SuccessDataResult<User>(user);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(MessageReurns.Update);
        }
    }
}
