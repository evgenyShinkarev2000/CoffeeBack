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
                var claimsIdentity = new ClaimsIdentity();

                var role = context.Request.Headers["Role"].FirstOrDefault();
                if (role != null)
                {
                    claimsIdentity.AddClaim(new Claim("Role", role));
                }
                var idSrting = context.Request.Headers["Id"].FirstOrDefault();
                if (idSrting != null)
                {
                    claimsIdentity.AddClaim(new Claim("Id", idSrting));
                }

                context.User.AddIdentity(claimsIdentity);

                return next();
            });
            app.UseAuthorization();
        }
    }
}
