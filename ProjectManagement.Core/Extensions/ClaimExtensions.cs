using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProjectManagement.Core.Extensions
{
    public static class ClaimExtensions
    {
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }

        public static void AddFullName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddUserName(this ICollection<Claim> claims, string userName)
        {
            claims.Add(new Claim("UserName", userName));
        }

        public static void AddUserId(this ICollection<Claim> claims, string userId)
        {
            claims.Add(new Claim("UserId", userId));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}
