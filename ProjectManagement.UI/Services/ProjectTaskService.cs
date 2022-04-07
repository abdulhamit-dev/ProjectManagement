using ProjectManagement.UI.Models;
using ProjectManagement.UI.Models.ProjectTask;

namespace ProjectManagement.UI.Services
{
    public class ProjectTaskService: BaseService
    {
        public ProjectTaskService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor) : base(httpClient, httpContextAccessor)
        {
        }


        public async Task<Result> Add(ProjectTaskAddUpdateVM projectTaskAddUpdateVM) => await Post<ProjectTaskAddUpdateVM>(projectTaskAddUpdateVM, "projectTask/add");
        public async Task<Result> Update(ProjectTaskAddUpdateVM projectTaskAddUpdateVM) => await Put<ProjectTaskAddUpdateVM>(projectTaskAddUpdateVM, "projectTask/update");
        public async Task<Result> Delete(int id) => await Delete(id, "projectTask/delete/");
        public async Task<OnlyDataResult<ProjectTaskAddUpdateVM>> GetById(int id) => await GetById<ProjectTaskAddUpdateVM>(id, "projectTask/getbyid/");
        public async Task<DataResult<ProjectTasksVM>> GetAll() => await Get<ProjectTasksVM>("projectTask/getall");
        public async Task<DataResult<ProjectTasksVM>> GetProjectTasks(int projectId) => await Get<ProjectTasksVM>("projectTask/GetProjectTasks/" + projectId);
    }
}
