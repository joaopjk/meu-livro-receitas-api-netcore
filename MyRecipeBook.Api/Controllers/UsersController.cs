using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UseCases.Users.Register;
using MyRecipeBook.Comunication.Requests;
using MyRecipeBook.Comunication.Responses;

namespace MyRecipeBook.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> Register([FromServices] IRegisterUserUseCase useCase, RequestRegisterUserJson request)
        {
            return Created(string.Empty, await useCase.Execute(request));
        }
    }
}
