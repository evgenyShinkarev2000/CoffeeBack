using CoffeeBack.Authorization;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CoffeeBack.Services
{
    public interface IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 0 for unknown role
        /// </returns>
        int RoleToAccessLevel(string role);
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

        public int RoleToAccessLevel(string role)
        {
            if (role != null && roleNameToAccessLevel.TryGetValue(role, out var accessLevel))
            {
                return accessLevel;
            }

            return 0;
        }
    }
}
