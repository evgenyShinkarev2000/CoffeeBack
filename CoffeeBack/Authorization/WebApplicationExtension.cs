using Microsoft.AspNetCore.Builder;
using System.Linq;
using System.Security.Claims;

namespace CoffeeBack.Authorization
{
    public static class WebApplicationExtension
    {
        public static void UseAppAuthorization(this WebApplication app)
        {
            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyHeader();
                options.AllowAnyMethod();
            });
            app.Use((context, next) =>
            {
                var role = context.Request.Headers["Role"].FirstOrDefault();
                if (role != null)
                {
                    context.User.AddIdentity(new ClaimsIdentity(Enumerable.Repeat(new Claim("Role", role), 1)));
                }

                return next();
            });
            app.UseAuthorization();
        }
    }
}
