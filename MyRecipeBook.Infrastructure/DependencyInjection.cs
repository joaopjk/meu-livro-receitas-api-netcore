using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Repositories;
using MyRecipeBook.Domain.Repositories.Users;
using MyRecipeBook.Infrastructure.DataAccess;
using MyRecipeBook.Infrastructure.DataAccess.Repositories;

namespace MyRecipeBook.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            AddDbContext(services);
            AddUserRepositories(services);
        }

        private static void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext<MyRecipeBookDbContext>(options =>
            {
                options.UseSqlServer(
                    "Data Source=localhost;" +
                    "Initial Catalog=meulivroreceitas;" +
                    "User ID=sa;" +
                    "Password=Root@123root;" +
                    //"Trusted_Connection=True;" +
                    "Encrypt=True;" +
                    "TrustServerCertificate=True;");
            });
        }

        private static void AddUserRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
