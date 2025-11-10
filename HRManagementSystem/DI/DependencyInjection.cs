using FluentValidation;
using HRManagementSystem.Common.Views;
using HRManagementSystem.Data.Contexts;
using HRManagementSystem.Data.Middlewares;
using HRManagementSystem.Data.Repositories;
using HRManagementSystem.Features.Common.IsAnyChildAssignedGeneric;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection;

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
            services.AddValidatorsFromAssembly(typeof(Program).Assembly);
            #region Generic Child Check Handlers Registration
            //Generic Child Check Handlers Registration
            var maps = new (Type Parent, Type Child, Type Key)[]
         {
                (typeof(Organization), typeof(Company),  typeof(int)),
                (typeof(Company),      typeof(Branch),   typeof(int)),
                (typeof(Branch),       typeof(Department), typeof(int)),
                (typeof(Department),   typeof(Team),     typeof(int)),
         };
            foreach (var (p, c, k) in maps)
            {
                var req = typeof(IsAnyChildAssignedQuery<,,>).MakeGenericType(p, c, k);
                var resp = typeof(RequestResult<bool>);
                var svc = typeof(IRequestHandler<,>).MakeGenericType(req, resp);
                var impl = typeof(IsAnyChildAssignedQueryHandler<,,>).MakeGenericType(p, c, k);
                services.AddTransient(svc, impl);
            }
            #endregion
            services.AddScoped<GlobalErrorHandlerMiddleware>();
            services.AddScoped<TransactionMiddleware>();
            services.AddScoped(typeof(IGeneralRepository<,>), typeof(GeneralRepository<,>));
            services.AddScoped(typeof(EndPointBaseParameters<>));
            services.AddScoped(typeof(RequestHandlerBaseParameters<,>));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<UserState>();

            return services;
        }
    }
}
