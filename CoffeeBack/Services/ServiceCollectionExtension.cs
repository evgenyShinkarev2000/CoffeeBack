using Microsoft.Extensions.DependencyInjection;

namespace CoffeeBack.Services
{
    public static class ServiceCollectionExtension
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<IUserService, UserService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
        }
    }
}
