using ProjectManagement.Business.Abstract;
using ProjectManagement.Business.Constant;
using ProjectManagement.Business.ValidationRules.FluentValidation;
using ProjectManagement.Core.Aspects.Autofac.Caching;
using ProjectManagement.Core.Aspects.Autofac.Validation;
using ProjectManagement.Core.Aspects.Logging;
using ProjectManagement.Core.CrossCuttingConcerns.Logging.Serilog;
using ProjectManagement.Core.Utilities.Result;
using ProjectManagement.DataAccess.Abstract;
using ProjectManagement.Entities.Concrete;
using ProjectManagement.Entities.Dtos.Project;

namespace ProjectManagement.Business.Concrete
{
    public class ProjectManager : IProjectService
    {
        IProjectDal _projectDal;

        public ProjectManager(IProjectDal projectDal)
        {
            _projectDal = projectDal;
        }


        [ValidationAspect(typeof(ProjectValidator))]
        [CacheRemoveAspect("IProjectService.Get")]
        public IResult Add(Project project)
        {
            _projectDal.Add(project);
            return new SuccessResult(MessageReturns.Add);
        }

        public IResult Delete(int id)
        {
            var project = _projectDal.Get(x => x.Id == id);
            if (project is null)
                return new ErrorResult(MessageReturns.NotFound);
            else
            {
                _projectDal.Delete(project);
                return new SuccessResult(MessageReturns.Delete);
            }
        }

        [LogAspect(typeof(SeqLogger))]
        [CacheAspect(5)]
        public IDataResult<List<Project>> GetAll()
        {
            return new SuccessDataResult<List<Project>>(_projectDal.GetAll());
        }

        public IDataResult<Project> GetById(int id)
        {
            var project = _projectDal.Get(x => x.Id == id);
            if (project is null)
                return new ErrorDataResult<Project>(null, MessageReturns.NotFound);

            return new SuccessDataResult<Project>(project);

        }

        [ValidationAspect(typeof(ProjectValidator))]
        [CacheRemoveAspect("IProjectService.Get")]
        public IResult Update(Project project)
        {
            _projectDal.Update(project);
            return new SuccessResult(MessageReturns.Update);
        }
    }
}
