using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeBack.Authorization
{
    public class RoleAtLeastHandler : AuthorizationHandler<RoleAtLeastRequirment>
    {
        private readonly IRoleAccessLevelService roleAccessLevelService;

        public RoleAtLeastHandler(IRoleAccessLevelService roleAccessLevelService)
        {
            this.roleAccessLevelService = roleAccessLevelService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleAtLeastRequirment requirement)
        {
            var userRole = context.User.Claims.FirstOrDefault(claim => claim.Type == "Role")?.Value;
            if (userRole != null)
            {
                if (roleAccessLevelService.CanAccess(userRole, requirement.Role))
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}
