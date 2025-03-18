
using MyRecipeBook.Api.Filters;
using MyRecipeBook.Api.Middleware;
using MyRecipeBook.Application;
using MyRecipeBook.Infrastructure;
using MyRecipeBook.Infrastructure.Migrations;

namespace MyRecipeBook.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMvc(opt => opt.Filters.Add(typeof(ExceptionFilter)));
            builder.Services.AddInfrastructure();
            builder.Services.AddApplication();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<CultureMiddleware>();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            Migrations(app);
            app.Run();
        }

        private static void Migrations(WebApplication app)
        {
            var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
            DataBaseMigration.Migrate(Environment.GetEnvironmentVariable("CONNECTION_STRING")!, serviceScope.ServiceProvider);
        }
    }
}
