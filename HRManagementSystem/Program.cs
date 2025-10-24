using HRManagementSystem.Data;
using HRManagementSystem.Data.Middlewares;
using HRManagementSystem.DI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HRManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDependencyInjection(builder.Configuration);

            var key = Encoding.ASCII.GetBytes(Constants.SecretKey);

            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new()
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidIssuer = "Upskilling",
                        ValidAudience = "Upskilling-front",
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                    };
                });

            builder.Services.AddAuthorization(opt =>
            {
                opt.AddPolicy("All", policy => policy.RequireRole("admin", "instructor", "sudent"));
                opt.AddPolicy("Admins", policy => policy.RequireRole("admin", "instructor"));
            });

            var app = builder.Build();

            //#region Migrate Database - Data Seeding
            //using var Scope = app.Services.CreateScope();
            //var dbContext = Scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            //var pendingMigrations = dbContext.Database.GetPendingMigrations();
            //if (pendingMigrations?.Any() ?? false)
            //{
            //    dbContext.Database.Migrate();
            //}
            //ApplicationDbContextSeeding.SeedData(dbContext);
            //#endregion

            app.UseMiddleware<GlobalErrorHandlerMiddleware>();
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<TransactionMiddleware>();
            app.MapControllers();

            app.Run();
        }
    }
}
