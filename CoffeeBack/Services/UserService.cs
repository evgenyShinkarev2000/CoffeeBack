using CoffeeBack.Authorization;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CoffeeBack.Services
{
    /// <summary>
    /// singleton
    /// </summary>
    public interface IUserService
    {
        Task<IEnumerable<string>> GetKnownRoles();
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 0 for unknown role
        /// </returns>
        Task<int> RoleToAccessLevel(string role);
    }

    public class UserService : IUserService
    {
        private readonly Dictionary<string, int> roleNameToAccessLevel = new();
        public UserService(ILogger<UserService> logger)
        {
            var knownRoleAccessLevelPropertyNameToAccessLevel = typeof(KnowRoleAccessLevel)
                .GetFields(BindingFlags.Static | BindingFlags.Public)
                .ToDictionary(propInfo => propInfo.Name, propInfo => propInfo.GetValue(null));
            foreach (var knownRolePropInfo in typeof(KnownRoleName).GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                if (knownRoleAccessLevelPropertyNameToAccessLevel.TryGetValue(knownRolePropInfo.Name, out var accessLevel))
                {
                    roleNameToAccessLevel.Add((string)knownRolePropInfo.GetValue(null), (int)accessLevel);
                }
                else
                {
                    logger.LogWarning($"Found role {knownRolePropInfo.Name} without access level");
                    roleNameToAccessLevel.Add((string)knownRolePropInfo.GetValue(null), 0);
                }
            }
        }

        public Task<IEnumerable<string>> GetKnownRoles()
        {
            return Task.FromResult(roleNameToAccessLevel.Keys.AsEnumerable());
        }

        public Task<int> RoleToAccessLevel(string role)
        {
            if (role != null && roleNameToAccessLevel.TryGetValue(role, out var accessLevel))
            {
                return Task.FromResult(accessLevel);
            }

            return Task.FromResult(0);
        }
    }
}
