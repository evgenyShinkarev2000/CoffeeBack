using CoffeeBack.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeBack.Data
{
    public static class ServiceCollectionExtension
    {
        public static void AddAppData(this IServiceCollection services)
        {
            services.AddScoped<ITextLectureRepository, TextLectureRepository>();
            services.AddScoped<IVideoLectureRepository, VideoLectureRepository>();
        }
    }
}
