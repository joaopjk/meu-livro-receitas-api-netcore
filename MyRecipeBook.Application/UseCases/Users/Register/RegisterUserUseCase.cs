using AutoMapper;
using MyRecipeBook.Application.Services.Cryptography;
using MyRecipeBook.Comunication.Requests;
using MyRecipeBook.Comunication.Responses;
using MyRecipeBook.Domain.Entities;
using MyRecipeBook.Domain.Repositories.Users;
using MyRecipeBook.Exceptions;

namespace MyRecipeBook.Application.UseCases.Users.Register
{
    public class RegisterUserUseCase(
        IUserWriteOnlyRepository userWriteOnlyRepository,
        IUserReadOnlyRepository userReadOnlyRepository,
        IMapper mapper) : IRegisterUserUseCase
    {
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository = userWriteOnlyRepository;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository = userReadOnlyRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
        {
            Validate(request);

            var user = _mapper.Map<User>(request);
            user.Password = PasswordEncripter.Encrypt(request.Password);

            await _userWriteOnlyRepository.Add(user);

            return new ResponseRegisteredUserJson
            {
                Name = request.Name
            };
        }

        private static void Validate(RequestRegisterUserJson request)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                throw new ErrorOnValidationException(
                    [.. result.Errors.Select(error => error.ErrorMessage)]);
            }
        }
    }
}
