using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Application.Services.Mapping;
using MyRecipeBook.Application.UseCases.Users.Register;

namespace MyRecipeBook.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddAutoMapper(services);
            AddUseCases(services);
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddScoped(opt => new MapperConfiguration(config =>
            {
                config.AddProfile(new AutoMapping());
            }).CreateMapper());
        }
    }
}
