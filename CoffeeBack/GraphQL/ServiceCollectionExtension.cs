using _66BitTaskApi.GraphQL.Mappers;
using CoffeeBack.GraphQL;
using CoffeeBack.GraphQL.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace _66BitTaskApi.GraphQL
{
    public static class ServiceCollectionExtension
    {
        public static void AddAppGraphQl(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(GraphQlToDataAutoMapperProfile));

            services.AddSingleton<IAddTextLectureInputToData, AddTextLectureInputToData>();
            services.AddSingleton<IUpdateTextLectureInputToData, UpdateTextLectureInputToData>();

            services.AddSingleton<IAddVideoLectureInputToData, AddVideoLectureInputToData>();
            services.AddSingleton<IUpdateVideoLectureInputToData, UpdateVideoLectureInputToData>();

            services.AddGraphQLServer()
                .AddInMemorySubscriptions()
                .AddQueryType<Queries>()
                .AddMutationType<Mutations>()
                .AddProjections();
        }
    }
}
