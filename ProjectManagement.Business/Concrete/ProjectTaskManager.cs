using ProjectManagement.Business.Abstract;
using ProjectManagement.Business.Constant;
using ProjectManagement.Business.ValidationRules.FluentValidation;
using ProjectManagement.Core.Aspects.Autofac.Validation;
using ProjectManagement.Core.Utilities.Result;
using ProjectManagement.DataAccess.Abstract;
using ProjectManagement.Entities.Concrete;

namespace ProjectManagement.Business.Concrete
{
    public class ProjectTaskManager : IProjectTaskService
    {
        IProjectTaskDal _projectTaskDal;
        public ProjectTaskManager(IProjectTaskDal projectTaskDal)
        {
            _projectTaskDal = projectTaskDal;
        }
        [ValidationAspect(typeof(ProjectTaskValidator))]
        public IResult Add(ProjectTask projectTask)
        {
            _projectTaskDal.Add(projectTask);
            return new SuccessResult(MessageReurns.Add);
        }

        public IResult Delete(int id)
        {
            var projectTask = _projectTaskDal.Get(x => x.Id == id);
            if (projectTask is null)
                return new ErrorResult(MessageReurns.NotFound);
            else
            {
                _projectTaskDal.Delete(projectTask);
                return new SuccessResult(MessageReurns.Delete);
            }
        }

        public IDataResult<List<ProjectTask>> GetAll()
        {
            return new SuccessDataResult<List<ProjectTask>>(_projectTaskDal.GetAll());
        }

        public IDataResult<ProjectTask> GetById(int id)
        {

            var projectTask = _projectTaskDal.Get(x => x.Id == id);
            if (projectTask is null)
                return new ErrorDataResult<ProjectTask>(null, MessageReurns.NotFound);

            return new SuccessDataResult<ProjectTask>(projectTask);
        }
        [ValidationAspect(typeof(ProjectTaskValidator))]
        public IResult Update(ProjectTask projectTask)
        {
            _projectTaskDal.Update(projectTask);
            return new SuccessResult(MessageReurns.Update);
        }
    }
}
