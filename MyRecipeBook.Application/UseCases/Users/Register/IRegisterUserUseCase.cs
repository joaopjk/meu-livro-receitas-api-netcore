using MyRecipeBook.Comunication.Requests;
using MyRecipeBook.Comunication.Responses;

namespace MyRecipeBook.Application.UseCases.Users.Register
{
    public interface IRegisterUserUseCase
    {
        Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
    }
}
