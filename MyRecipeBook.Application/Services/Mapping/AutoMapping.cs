using AutoMapper;
using MyRecipeBook.Comunication.Requests;
using MyRecipeBook.Domain.Entities;

namespace MyRecipeBook.Application.Services.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToDomain();
        }

        private void RequestToDomain()
        {
            CreateMap<RequestRegisterUserJson, User>()
                .ForMember(dest => dest.Password,
                           opt => opt.Ignore());
        }
    }
}
