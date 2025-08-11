using AutoMapper;
using Grandeur_BE_DotNet.Data;
using Grandeur_BE_DotNet.DTO;
using Grandeur_BE_DotNet.Models.Entitiles;
using Grandeur_BE_DotNet.Services;
using Microsoft.EntityFrameworkCore;

namespace Grandeur_BE_DotNet.Repositories.Implementation;

public class UserRepository(AppDbContext context, IMapper mapper, ITokenService tokenService) : IUserRepository
{
    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await context.Users.ToListAsync();
    }

    public async Task<UserDto> Login(UserLoginDto userLoginDto)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Email == userLoginDto.Email) ?? throw new Exception("User doesnot exists");
        if (user.Password != userLoginDto.Password) throw new Exception("Incorrect Password");

        return new UserDto
        {
            Email = user.Email,
            Token = tokenService.CreateToken(user)
        };
    }

    public async Task<UserDto> RegisterUser(UserSignInDto userSignInDto)
    {
        if (await UserEmailExists(userSignInDto.Email)) throw new Exception($"User with email {userSignInDto.Email} already exists");
        var user = mapper.Map<User>(userSignInDto);
        context.Users.Add(user);
        return new UserDto
        {
            Email = user.Email,
            Token = tokenService.CreateToken(user)
        };
    }

    public Task<UserDto> VerifyEmail()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<User> GetUserAsync(int id)
    {
        var user = await context.Users.FirstAsync(x => x.Id == id) ?? throw new Exception("Unable to identify the user, Please login again.");
        return user;
    }

    // Private method to check if the user is present or not
    private async Task<bool> UserEmailExists(string email)
    {
        var user = await context.Users.FirstAsync(x => x.Email == email);
        return user != null;
    }
}
