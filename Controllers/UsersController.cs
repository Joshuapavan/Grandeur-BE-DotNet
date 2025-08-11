using Grandeur_BE_DotNet.DTO;
using Grandeur_BE_DotNet.Models.Entitiles;
using Grandeur_BE_DotNet.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Grandeur_BE_DotNet.Controllers;


// api/users
public class UsersController(IUserRepository userRepository) : BaseController
{
    // api/users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsersAsync()
    {
        return Ok(await userRepository.GetUsersAsync());
    }

    // api/users/sign_up
    [HttpPost("sign_up")]
    public async Task<ActionResult<UserDto>> RegisterUser([FromBody] UserSignInDto userSignInDto)
    {
        return Ok(await userRepository.RegisterUser(userSignInDto));
    }

    // To-Do 
    // [HttpGet("verify_email")]
    // public async Task<ActionResult<UserDto>> VerifyEmail()
    // {
    //     return Ok();
    // }

    // api/users/login
    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login([FromBody] UserLoginDto userLoginDto)
    {
        return Ok(await userRepository.Login(userLoginDto));
    }

}
