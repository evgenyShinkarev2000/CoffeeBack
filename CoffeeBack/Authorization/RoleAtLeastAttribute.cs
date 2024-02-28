using Microsoft.AspNetCore.Authorization;
using System;

namespace CoffeeBack.Authorization
{
    [Obsolete("Doesn't work with hot chocolate")]
    public class RoleAtLeastAttribute : AuthorizeAttribute, IAuthorizationRequirement
    {
        public string Role { get; }
        public RoleAtLeastAttribute(string role)
        {
            Role = role;
        }
    }
}
