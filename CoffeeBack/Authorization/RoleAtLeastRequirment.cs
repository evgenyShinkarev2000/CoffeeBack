using Microsoft.AspNetCore.Authorization;

namespace CoffeeBack.Authorization
{
    public class RoleAtLeastRequirment: IAuthorizationRequirement
    {
        public string Role { get; }
        public RoleAtLeastRequirment(string role)
        {
            Role = role;
        }
    }
}
