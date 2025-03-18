using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Repositories;
using MyRecipeBook.Domain.Repositories.Users;
using MyRecipeBook.Infrastructure.DataAccess;
using MyRecipeBook.Infrastructure.DataAccess.Repositories;
using System.Reflection;

namespace MyRecipeBook.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            AddDbContext(services);
            AddUserRepositories(services);
            AddFluentMigrator(services);
        }

        private static void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext<MyRecipeBookDbContext>(options =>
            {
                options.UseSqlServer(Environment.GetEnvironmentVariable("CONNECTION_STRING")!);
            });
        }

        private static void AddUserRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddFluentMigrator(IServiceCollection services)
        {
            services.AddFluentMigratorCore()
                .ConfigureRunner(opt =>
                {
                    opt.AddSqlServer()
                        .WithGlobalConnectionString(Environment.GetEnvironmentVariable("CONNECTION_STRING")!)
                        .ScanIn(Assembly.Load("MyRecipeBook.Infrastructure"))
                        .For.All();
                });
        }
    }
}
