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
    public class RoleManager : IRoleService
    {
        IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public IResult Add(Role role)
        {
            _roleDal.Add(role);
            return new SuccessResult(MessageReurns.Add);
        }

        public IResult Delete(int id)
        {
            var role = _roleDal.Get(x => x.Id == id);
            if (role is null)
                return new ErrorResult(MessageReurns.NotFound);
            else
            {
                _roleDal.Delete(role);
                return new SuccessResult(MessageReurns.Delete);
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
                return new ErrorDataResult<Role>(null, MessageReurns.NotFound);

            return new SuccessDataResult<Role>(role);
        }

        public IResult Update(Role role)
        {
            _roleDal.Update(role);
            return new SuccessResult(MessageReurns.Update);
        }
    }
}
