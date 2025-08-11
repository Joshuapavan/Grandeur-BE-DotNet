using AutoMapper;
using Grandeur_BE_DotNet.DTO;

namespace Grandeur_BE_DotNet.Helpers.Mapper;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<UserSignInDto, UserDto>();
    }

}
