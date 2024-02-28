using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace CoffeeBack.Authorization
{
    public class RoleAtLeastPolicyProvider : IAuthorizationPolicyProvider
    {
        public const string PolicyPrefix = "RoleAtLeast";
        private readonly DefaultAuthorizationPolicyProvider fallbackPolicyProvider;

        public RoleAtLeastPolicyProvider(IOptions<AuthorizationOptions> options)
        {
            fallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => fallbackPolicyProvider.GetDefaultPolicyAsync();

        public Task<AuthorizationPolicy> GetFallbackPolicyAsync() => fallbackPolicyProvider.GetFallbackPolicyAsync();

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            if (policyName.StartsWith(PolicyPrefix))
            {
                var policy = new AuthorizationPolicyBuilder();
                policy.AddRequirements(new RoleAtLeastRequirment(policyName.Substring(PolicyPrefix.Length)));

                return Task.FromResult(policy.Build());
            }

            return fallbackPolicyProvider.GetPolicyAsync(policyName);
        }
    }
}
