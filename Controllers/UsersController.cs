using Grandeur_BE_DotNet.Data;
using Grandeur_BE_DotNet.Models.Entitiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Grandeur_BE_DotNet.Controllers;


// api/users
public class UsersController(AppDbContext context) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsersAsync()
    {
        return Ok(await context.Users.ToListAsync());
    }

    
}
