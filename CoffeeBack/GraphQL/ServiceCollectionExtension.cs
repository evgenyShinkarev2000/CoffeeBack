using _66BitTaskApi.GraphQL.Mappers;
using CoffeeBack.GraphQL;
using Microsoft.Extensions.DependencyInjection;

namespace _66BitTaskApi.GraphQL
{
    public static class ServiceCollectionExtension
    {
        public static void AddAppGraphQl(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(GraphQlToDataAutoMapperProfile));

            services.AddGraphQLServer()
                .AddInMemorySubscriptions()
                .AddQueryType<Queries>()
                .AddMutationType<Mutations>()
                .AddProjections();
        }
    }
}
