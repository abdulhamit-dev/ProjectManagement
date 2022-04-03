using ProjectManagement.Business.Abstract;
using ProjectManagement.Business.Constant;
using ProjectManagement.Business.ValidationRules.FluentValidation;
using ProjectManagement.Core.Aspects.Autofac.Validation;
using ProjectManagement.Core.Utilities.Result;
using ProjectManagement.DataAccess.Abstract;
using ProjectManagement.Entities.Concrete;

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
        public IResult Add(Project project)
        {
            _projectDal.Add(project);
            return new SuccessResult(MessageReurns.Add);
        }

        public IResult Delete(int id)
        {
            var project = _projectDal.Get(x => x.Id == id);
            if (project is null)
                return new ErrorResult(MessageReurns.NotFound);
            else
            {
                _projectDal.Delete(project);
                return new SuccessResult(MessageReurns.Delete);
            }
        }

        public IDataResult<List<Project>> GetAll()
        {
            return new SuccessDataResult<List<Project>>(_projectDal.GetAll());
        }

        public IDataResult<Project> GetById(int id)
        {
            var project = _projectDal.Get(x => x.Id == id);
            if (project is null)
                return new ErrorDataResult<Project>(null, MessageReurns.NotFound);

            return new SuccessDataResult<Project>(project);

        }

        [ValidationAspect(typeof(ProjectValidator))]
        public IResult Update(Project project)
        {
            _projectDal.Update(project);
            return new SuccessResult(MessageReurns.Update);
        }
    }
}
