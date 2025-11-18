using FluentValidation;
using HRManagementSystem.Common.Views;
using HRManagementSystem.Data.Contexts.ApplicationDbContext;
using HRManagementSystem.Data.Middlewares;
using HRManagementSystem.Data.Repositories;
using HRManagementSystem.Features.Common.HierarchyLookup;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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

            var apiAssembly = Assembly.GetExecutingAssembly();
            var apiGroups = ApiGroupDiscovery.Discover(apiAssembly);
            services.AddSingleton<IReadOnlyList<ApiGroup>>(apiGroups);

            services.AddControllers(options =>
            {
                options.Conventions.Add(new ApiGroupConvention());
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(
                    new System.Text.Json.Serialization.JsonStringEnumConverter());
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                if (apiGroups.Any())
                {
                    foreach (var group in apiGroups)
                    {
                        options.SwaggerDoc(group.Name, new OpenApiInfo
                        {
                            Title = group.DisplayName,
                            Version = "v1"
                        });
                    }

                    options.DocInclusionPredicate((docName, apiDesc) =>
                    {
                        if (string.IsNullOrWhiteSpace(apiDesc.GroupName))
                        {
                            return false;
                        }

                        return string.Equals(apiDesc.GroupName, docName, StringComparison.OrdinalIgnoreCase);
                    });

                    options.TagActionsBy(apiDesc =>
                    {
                        if (apiDesc.ActionDescriptor is ControllerActionDescriptor controllerDescriptor)
                        {
                            var attr = controllerDescriptor.ControllerTypeInfo.GetCustomAttribute<ApiGroupAttribute>(inherit: true);
                            if (attr is not null)
                            {
                                if (!string.IsNullOrWhiteSpace(attr.SectionName))
                                {
                                    return new[] { attr.SectionName };
                                }

                                if (!string.IsNullOrWhiteSpace(attr.GroupName))
                                {
                                    return new[] { attr.GroupName };
                                }
                            }
                        }

                        if (!string.IsNullOrWhiteSpace(apiDesc.GroupName))
                        {
                            return new[] { apiDesc.GroupName };
                        }

                        var controllerName = apiDesc.ActionDescriptor.RouteValues["controller"];
                        return new[] { controllerName ?? "General" };
                    });
                }
                else
                {
                    options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "HRManagementSystem API",
                        Version = "v1"
                    });
                }

                options.CustomSchemaIds(type => type.FullName ?? type.Name);

                var xmlFile = $"{apiAssembly.GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                {
                    options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
                }

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter JWT Bearer token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                options.AddSecurityDefinition("Bearer", securityScheme);
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        securityScheme,
                        Array.Empty<string>()
                    }
                });
            });
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(apiAssembly));
            services.AddValidatorsFromAssembly(typeof(Program).Assembly);
            services.AddScoped<GlobalErrorHandlerMiddleware>();
            services.AddScoped<TransactionMiddleware>();
            services.AddScoped(typeof(IGeneralRepository<,>), typeof(GeneralRepository<,>));
            services.AddScoped<IHierarchyLookupHelper, HierarchyLookupHelper>();
            services.AddScoped(typeof(EndPointBaseParameters<>));
            services.AddScoped(typeof(RequestHandlerBaseParameters<,>));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<UserState>();

            return services;
        }
    }
}
