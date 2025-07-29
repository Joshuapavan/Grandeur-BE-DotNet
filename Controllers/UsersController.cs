using AutoMapper;
using Grandeur_BE_DotNet.Data;
using Grandeur_BE_DotNet.DTO;
using Grandeur_BE_DotNet.Models.Entitiles;
using Grandeur_BE_DotNet.Repositories;
using Grandeur_BE_DotNet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Grandeur_BE_DotNet.Controllers;


// api/users
public class UsersController(IUserRepository userRepository, ITokenService tokenService) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsersAsync()
    {
        return Ok(await userRepository.GetUsersAsync());
    }

    [HttpPost("sign_up")]
    public async Task<ActionResult<UserDto>> RegisterUser([FromBody] UserSignInDto userSignInDto)
    {
        return Ok(await userRepository.RegisterUser(userSignInDto));
    }

    [HttpGet("verify_email")]
    public async Task<ActionResult<UserDto>> VerifyEmail()
    {
        return Ok();
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login([FromBody] UserLoginDto userLoginDto)
    {
        return Ok();
    }

}
