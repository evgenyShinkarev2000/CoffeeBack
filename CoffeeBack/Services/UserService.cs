using CoffeeBack.Authorization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
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
        private readonly Dictionary<string, int> roleNameToAccessLevel;
        public UserService()
        {
            roleNameToAccessLevel = typeof(KnownRole).GetProperties()
            .Select(propInfo => propInfo.GetValue(null))
            .Where(mayBeKnowRoleItem => mayBeKnowRoleItem is KnownRoleItem)
            .Cast<KnownRoleItem>()
            .ToDictionary(knownRoleItem => knownRoleItem.Name, knownRoleItem => knownRoleItem.AccessLevel);
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
