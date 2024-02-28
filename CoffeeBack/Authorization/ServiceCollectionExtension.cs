using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeBack.Authorization
{
    public static class ServiceCollectionExtension
    {
        public static void AddAppAuthorization(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationPolicyProvider, RoleAtLeastPolicyProvider>();
            services.AddSingleton<IAuthorizationHandler, RoleAtLeastHandler>();
            services.AddCors();
            services.AddAuthorization();
        }
    }
}
