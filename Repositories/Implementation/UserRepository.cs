using System;
using AutoMapper;
using Grandeur_BE_DotNet.Data;
using Grandeur_BE_DotNet.DTO;
using Grandeur_BE_DotNet.Models.Entitiles;
using Microsoft.EntityFrameworkCore;

namespace Grandeur_BE_DotNet.Repositories.Implementation;

public class UserRepository(AppDbContext context, IMapper mapper) : IUserRepository
{
    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await context.Users.ToListAsync();
    }

    public Task<UserDto> Login(UserLoginDto userLoginDto)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> RegisterUser(UserSignInDto userSignInDto)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> VerifyEmail()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    // Private method to check if the user is present or not
}
