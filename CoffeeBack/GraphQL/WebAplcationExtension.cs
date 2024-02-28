using Microsoft.AspNetCore.Builder;

namespace CoffeeBack.GraphQL
{
    public static class WebAplcationExtension
    {
        public static void UseAppGrapgQL(this WebApplication app)
        {
            app.MapGraphQL();
        }
    }
}
