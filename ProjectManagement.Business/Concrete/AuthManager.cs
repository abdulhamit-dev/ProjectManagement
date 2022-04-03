using ProjectManagement.Business.Abstract;
using ProjectManagement.Business.Constant;
using ProjectManagement.Core.Entities.Concrete;
using ProjectManagement.Core.Utilities.Result;
using ProjectManagement.Core.Utilities.Security.JWT;
using ProjectManagement.Entities.Dtos;
using ProjectManagement.Entities.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Business.Concrete
{
    public class AuthManager:IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        public AuthManager(ITokenHelper tokenHelper, IUserService userService)
        {
            _tokenHelper = tokenHelper;
            _userService = userService;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaim(user.Id);

            List<Role> roles = new List<Role>();

            foreach (var item in claims.Data)
                roles.Add(new Role() { Id = item.RoleId, Name = item.Name });

            var accessToken = _tokenHelper.CreateToken(user, roles);
            return new SuccessDataResult<AccessToken>(accessToken, MessageReturns.CreateToken);
        }

        public IDataResult<User> Login(UserLoginDto userLoginDto)
        {
            var user = _userService.GetByName(userLoginDto.UserName);

            if (user.Data == null)
            {
                return new ErrorDataResult<User>(MessageReturns.NotFound);
            }
            // automapper !!
            User newUser = new User
            {
                UserName = user.Data.UserName,
                IsActive = user.Data.IsActive,
                Email = user.Data.Email,
                Id = user.Data.Id,
                FullName = user.Data.FullName
            };

            return new SuccessDataResult<User>(newUser,MessageReturns.Success);
        }
    }
}
