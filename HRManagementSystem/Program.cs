using HRManagementSystem.Data.Contexts.ApplicationDbContext;
using HRManagementSystem.Data.DataSeed;
using HRManagementSystem.Data.Middlewares;
using HRManagementSystem.DI;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDependencyInjection(builder.Configuration);

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
