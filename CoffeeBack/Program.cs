using Microsoft.AspNetCore.Builder;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CoffeeBack.Data;
using _66BitTaskApi.GraphQL;
using CoffeeBack.Data.Repositories;

namespace CoffeeBack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContextPool<AppDbContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite") ?? throw new NullReferenceException());
            });

            builder.Services.AddScoped<ITextLectureRepository, TextLectureRepository>();
            builder.Services.AddScoped<IVideoLectureRepository, VideoLectureRepository>();

            builder.Services.AddCors();
            builder.Services.AddAppGraphQl();

            var app = builder.Build();

            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyHeader();
                options.AllowAnyMethod();
            });
            app.UseHttpsRedirection();
            app.UseWebSockets();
            app.MapGraphQL();

            app.Run();
        }
    }

}
