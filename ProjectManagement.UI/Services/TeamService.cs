using ProjectManagement.UI.Models;
using ProjectManagement.UI.Models.Team;

namespace ProjectManagement.UI.Services
{
    public class TeamService : BaseService
    {
        public TeamService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor) : base(httpClient, httpContextAccessor)
        {
        }

        public async Task<Result> Add(TeamAddUpdateVM teamAddUpdateVM) => await Post<TeamAddUpdateVM>(teamAddUpdateVM, "team/add");
        public async Task<Result> Update(TeamAddUpdateVM teamAddUpdateVM) => await Put<TeamAddUpdateVM>(teamAddUpdateVM, "team/update");
        public async Task<Result> Delete(int id) => await Delete(id, "team/delete/");
        public async Task<OnlyDataResult<TeamAddUpdateVM>> GetById(int id) => await GetById<TeamAddUpdateVM>(id, "team/getbyid/");
        public async Task<DataResult<TeamVM>> GetAll() => await Get<TeamVM>("team/getall");
    }
}
