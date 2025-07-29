using System;
using Grandeur_BE_DotNet.DTO;
using Grandeur_BE_DotNet.Models.Entitiles;

namespace Grandeur_BE_DotNet.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsersAsync();

    Task<bool> SaveChangesAsync();
    Task<UserDto> RegisterUser(UserSignInDto userSignInDto);
    Task<UserDto> VerifyEmail();
    Task<UserDto> Login(UserLoginDto userLoginDto);
}
