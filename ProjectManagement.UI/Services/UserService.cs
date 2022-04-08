using ProjectManagement.UI.Models;
using ProjectManagement.UI.Models.User;

namespace ProjectManagement.UI.Services
{
    public class UserService:BaseService
    {
        public UserService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor) : base(httpClient, httpContextAccessor)
        {
        }

        public async Task<Result> Add(UserAddUpdateVM userAddUpdateVM) => await Post<UserAddUpdateVM>(userAddUpdateVM, "user/add");
        public async Task<Result> Update(UserAddUpdateVM userAddUpdateVM) => await Put<UserAddUpdateVM>(userAddUpdateVM, "user/update");
        public async Task<Result> Delete(int id) => await Delete(id, "user/delete/");
        public async Task<OnlyDataResult<UserAddUpdateVM>> GetById(int id) => await GetById<UserAddUpdateVM>(id, "user/getbyid/");
        public async Task<DataResult<UserVM>> GetAll() => await Get<UserVM>("user/getall");
    }
}
