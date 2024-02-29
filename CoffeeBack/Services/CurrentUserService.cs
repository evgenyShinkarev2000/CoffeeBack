using Microsoft.AspNetCore.Http;
using System.Linq;

namespace CoffeeBack.Services
{
    public interface ICurrentUserService
    {
        int Id { get; }
        string Role { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 0 for unknown user
        /// </returns>
        public int GetAccessLevel();
    }

    public class CurrentUserService : ICurrentUserService
    {
        private readonly IUserService userService;
        public int Id { get; }
        public string Role { get; }
        public CurrentUserService(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            this.userService = userService;

            var claims = httpContextAccessor.HttpContext.User.Claims;
            int.TryParse(claims.FirstOrDefault(c => c.Type == "Id")?.Value, out var Id);
            Role = claims.FirstOrDefault(c => c.Type == "Role")?.Value;
        }

        public int GetAccessLevel()
        {
            return userService.RoleToAccessLevel(Role).Result;
        }
    }
}
