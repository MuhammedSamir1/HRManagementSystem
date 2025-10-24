using System.Diagnostics;
using System.Reflection;
using FluentValidation;
using HRManagementSystem.Common.BaseEndPoints;
using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Data.Contexts.ApplicationDbContext;
using HRManagementSystem.Data.Middlewares;
using HRManagementSystem.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
               opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
               .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
               .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
               .EnableSensitiveDataLogging(true));


            services.AddControllers()
           .AddJsonOptions(options =>
           {
               options.JsonSerializerOptions.Converters.Add(
                   new System.Text.Json.Serialization.JsonStringEnumConverter());
           });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<GlobalErrorHandlerMiddleware>();
            services.AddScoped<TransactionMiddleware>();
            services.AddScoped(typeof(IGeneralRepository<,>), typeof(GeneralRepository<,>));
            services.AddScoped(typeof(EndPointBaseParameters<>));
            services.AddScoped(typeof(RequestHandlerBaseParameters<,>));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
