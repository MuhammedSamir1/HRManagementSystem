using HRManagementSystem.Data.Middlewares;
using HRManagementSystem.DI;

namespace HRManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDependencyInjection(builder.Configuration);

            var app = builder.Build();

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
