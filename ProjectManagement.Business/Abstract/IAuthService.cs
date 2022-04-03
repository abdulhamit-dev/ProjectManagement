using ProjectManagement.Core.Entities.Concrete;
using ProjectManagement.Core.Utilities.Result;
using ProjectManagement.Core.Utilities.Security.JWT;
using ProjectManagement.Entities.Dtos.User;

namespace ProjectManagement.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Login(UserLoginDto userLoginDto);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
