using Microsoft.AspNetCore.Builder;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CoffeeBack.Data;
using _66BitTaskApi.GraphQL;
using CoffeeBack.Data.Repositories;
using CoffeeBack.Authorization;
using CoffeeBack.GraphQL;
using CoffeeBack.Services;

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

            builder.Services.AddLogging();
            builder.Services.AddAppData();
            builder.Services.AddAppGraphQL();
            builder.Services.AddAppAuthorization();
            builder.Services.AddAppServices();

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseAppAuthorization();
            app.UseAppGrapgQL();

            app.Run();
        }
    }

}
