using CoffeeBack.Services;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeBack.Authorization
{
    public class RoleAtLeastHandler : AuthorizationHandler<RoleAtLeastRequirment>
    {
        private readonly IUserService userService;

        public RoleAtLeastHandler(IUserService userService)
        {
            this.userService = userService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleAtLeastRequirment requirement)
        {
            var userRole = context.User.Claims.FirstOrDefault(claim => claim.Type == "Role")?.Value;
            if (userRole != null)
            {
                if (userService.RoleToAccessLevel(userRole) >= userService.RoleToAccessLevel(requirement.Role))
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}
