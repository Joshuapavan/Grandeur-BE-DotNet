using System;
using AutoMapper;
using Grandeur_BE_DotNet.DTO;
using Grandeur_BE_DotNet.Models.Entitiles;

namespace Grandeur_BE_DotNet.Helpers.Mapper;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<UserSignInDto, UserDto>();
    }

}
