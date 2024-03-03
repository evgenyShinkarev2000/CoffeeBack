using CoffeeBack.GraphQL;
using CoffeeBack.GraphQL.Mapper;
using CoffeeBack.GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace _66BitTaskApi.GraphQL
{
    public static class ServiceCollectionExtension
    {
        public static void AddAppGraphQL(this IServiceCollection services)
        {

            services.AddAutoMapper(options =>
            {
                options.AddProfile<InputToDataAutoMapperProfile>();
            });

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
                .AddType<VideoLectureType>()
                .AddType<TextLectureType>()
                .AddAuthorization()
                .AddQueryType<Queries>()
                .AddMutationType<Mutations>()
                .AddProjections()
                .AddFiltering();
        }
    }
}
