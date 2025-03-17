using MyRecipeBook.Exceptions.ExceptionsBase;

namespace MyRecipeBook.Exceptions
{
    public class ErrorOnValidationException(IList<string> errors) : MyRecipeBookException
    {
        public IList<string> ErrorsMessages { get; } = errors;
    }
}
