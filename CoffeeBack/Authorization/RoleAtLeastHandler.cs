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

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleAtLeastRequirment requirement)
        {
            var userRole = context.User.Claims.FirstOrDefault(claim => claim.Type == "Role")?.Value;
            if (userRole != null)
            {
                var currentUserAccessLevel = userService.RoleToAccessLevel(userRole);
                var requiredAccessLevel = userService.RoleToAccessLevel(requirement.Role);
                await Task.WhenAll(currentUserAccessLevel, requiredAccessLevel);

                if (currentUserAccessLevel.Result >= requiredAccessLevel.Result)
                {
                    context.Succeed(requirement);
                }
            }
        }
    }
}
