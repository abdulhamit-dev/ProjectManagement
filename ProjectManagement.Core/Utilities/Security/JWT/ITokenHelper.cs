using ProjectManagement.Core.Entities.Concrete;

namespace ProjectManagement.Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<Role> operationClaims);
    }
}
