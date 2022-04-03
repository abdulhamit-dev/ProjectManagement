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
    internal class SubTaskManager : ISubTaskService
    {
        ISubTaskDal _subTaskDal;

        public SubTaskManager(ISubTaskDal subTaskDal)
        {
            _subTaskDal = subTaskDal;
        }
        [ValidationAspect(typeof(SubTaskValidator))]
        public IResult Add(SubTask subTask)
        {
            _subTaskDal.Add(subTask);
            return new SuccessResult(MessageReturns.Add);
        }

        public IResult Delete(int id)
        {
            var subTask = _subTaskDal.Get(x => x.Id == id);
            if (subTask is null)
                return new ErrorResult(MessageReturns.NotFound);
            else
            {
                _subTaskDal.Delete(subTask);
                return new SuccessResult(MessageReturns.Delete);
            }
        }

        public IDataResult<List<SubTask>> GetAll()
        {
            return new SuccessDataResult<List<SubTask>>(_subTaskDal.GetAll());
        }

        public IDataResult<SubTask> GetById(int id)
        {
            var subTask = _subTaskDal.Get(x => x.Id == id);
            if (subTask is null)
                return new ErrorDataResult<SubTask>(null, MessageReturns.NotFound);

            return new SuccessDataResult<SubTask>(subTask);
        }
        [ValidationAspect(typeof(SubTaskValidator))]
        public IResult Update(SubTask subTask)
        {
            _subTaskDal.Update(subTask);
            return new SuccessResult(MessageReturns.Update);
        }
    }
}
