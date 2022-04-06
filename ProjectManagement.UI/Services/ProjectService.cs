using ProjectManagement.UI.Models;
using ProjectManagement.UI.Models.Project;

namespace ProjectManagement.UI.Services
{
    public class ProjectService : BaseService
    {
        public ProjectService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor) : base(httpClient, httpContextAccessor)
        {
        }

        public async Task<Result> Add(ProjectAddUpdateVM projectAddUpdateVM) => await Post<ProjectAddUpdateVM>(projectAddUpdateVM, "project/add");
        public async Task<Result> Update(ProjectAddUpdateVM projectAddUpdateVM) => await Put<ProjectAddUpdateVM>(projectAddUpdateVM, "project/update");
        public async Task<Result> Delete(int id) => await Delete(id, "project/delete/");
        public async Task<OnlyDataResult<ProjectAddUpdateVM>> GetById(int id) => await GetById<ProjectAddUpdateVM>(id, "project/getbyid/");
        public async Task<DataResult<ProjectVM>> GetAll() => await Get<ProjectVM>("project/getall");
        public async Task<DataResult<ProjectTasksVM>> GetProjectTasks(int projectId) => await Get<ProjectTasksVM>("project/GetProjectTasks/" + projectId);
    }
}
