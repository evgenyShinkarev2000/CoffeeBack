﻿using CoffeeBack.Services.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeBack.Services
{
    public static class ServiceCollectionExtension
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddAutoMapper(options =>
            {
                options.AddProfile<DataToServiceAutoMapperProfile>();
            });

            services.AddHttpContextAccessor();
            services.AddSingleton<IUserService, UserService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IVideoLectureService, VideoLectureService>();
            services.AddScoped<ITextLectureService, TextLectureService>();
            services.AddScoped<IProgressService, ProgressService>();
        }
    }
}
