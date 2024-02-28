using _66BitTaskApi.GraphQL.Mappers;
using CoffeeBack.GraphQL;
using CoffeeBack.GraphQL.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace _66BitTaskApi.GraphQL
{
    public static class ServiceCollectionExtension
    {
        public static void AddAppGraphQL(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(GraphQlToDataAutoMapperProfile));

            services.AddSingleton<IAddTextLectureInputToData, AddTextLectureInputToData>();
            services.AddSingleton<IUpdateTextLectureInputToData, UpdateTextLectureInputToData>();
            services.AddSingleton<IRemoveTextLectureInputToData, RemoveTextLectureInputToData>();

            services.AddSingleton<IAddVideoLectureInputToData, AddVideoLectureInputToData>();
            services.AddSingleton<IUpdateVideoLectureInputToData, UpdateVideoLectureInputToData>();
            services.AddSingleton<IRemoveVideoLectureInputToData, RemoveVideoLectureInputToData>();

            services.AddSingleton<IAddPersonInputToData, AddPersonInputToData>();
            services.AddSingleton<IUpdatePersonInputToData, UpdatePersonInputToData>();
            services.AddSingleton<IRemovePersonInputToData, RemovePersonInputToData>();

            services.AddGraphQLServer()
                .AddAuthorization()
                .AddQueryType<Queries>()
                .AddMutationType<Mutations>()
                .AddProjections();
        }
    }
}
