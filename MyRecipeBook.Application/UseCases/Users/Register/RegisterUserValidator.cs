using FluentValidation;
using MyRecipeBook.Comunication.Requests;
using MyRecipeBook.Exceptions;

namespace MyRecipeBook.Application.UseCases.Users.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty()
                .WithMessage(ResourceMessagesException.NAME_EMPTY);

            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage(ResourceMessagesException.EMAIL_EMPTY)
                .EmailAddress()
                .WithMessage(ResourceMessagesException.EMAIL_INVALID);

            RuleFor(user => user.Password.Length)
                .NotEmpty()
                .WithMessage(ResourceMessagesException.PASSWORD_EMPTY)
                .GreaterThanOrEqualTo(6)
                .WithMessage(ResourceMessagesException.PASSWORD_MINIMUM_LENGTH);
        }
    }
}
