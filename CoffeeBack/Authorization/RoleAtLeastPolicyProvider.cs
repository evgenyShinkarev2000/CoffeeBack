using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace CoffeeBack.Authorization
{
    public class RoleAtLeastPolicyProvider : IAuthorizationPolicyProvider
    {
        private readonly DefaultAuthorizationPolicyProvider fallbackPolicyProvider;

        public RoleAtLeastPolicyProvider(IOptions<AuthorizationOptions> options)
        {
            fallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => fallbackPolicyProvider.GetDefaultPolicyAsync();

        public Task<AuthorizationPolicy> GetFallbackPolicyAsync() => fallbackPolicyProvider.GetFallbackPolicyAsync();

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            if (policyName.StartsWith(KnownAuthorizePolicy.RoleAtLeast))
            {
                var policy = new AuthorizationPolicyBuilder();
                policy.AddRequirements(new RoleAtLeastRequirment(policyName.Substring(KnownAuthorizePolicy.RoleAtLeast.Length)));

                return Task.FromResult(policy.Build());
            }

            return fallbackPolicyProvider.GetPolicyAsync(policyName);
        }
    }
}
