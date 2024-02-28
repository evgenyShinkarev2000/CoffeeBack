using System.Collections.Generic;
using System.Linq;

namespace CoffeeBack.Authorization
{
    public interface IRoleAccessLevelService
    {
        bool CanAccess(string userRole, string requiredRole);
    }

    public class RoleAccessLevelService : IRoleAccessLevelService
    {
        private readonly Dictionary<string, int> roleNameToAccessLevel;
        public RoleAccessLevelService()
        {
            roleNameToAccessLevel = typeof(KnownRole).GetProperties()
                .Select(propInfo => propInfo.GetValue(null))
                .Where(mayBeKnowRoleItem => mayBeKnowRoleItem is KnownRoleItem)
                .Cast<KnownRoleItem>()
                .ToDictionary(knownRoleItem => knownRoleItem.Name, knownRoleItem => knownRoleItem.AccessLevel);
        }
        public bool CanAccess(string userRole, string requiredRole)
        {
            if (roleNameToAccessLevel.TryGetValue(userRole, out var userAccessLevel)
                && roleNameToAccessLevel.TryGetValue(requiredRole, out var requiredAccessLevel))
            {
                return userAccessLevel >= requiredAccessLevel;
            }

            return false;
        }
    }
}
