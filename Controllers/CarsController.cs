using Grandeur_BE_DotNet.DTO;
using Grandeur_BE_DotNet.Extensions;
using Grandeur_BE_DotNet.Models.Entitiles;
using Grandeur_BE_DotNet.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Grandeur_BE_DotNet.Controllers;

public class CarsController(ICarRepository carRepository, IUserRepository userRepository) : ControllerBase
{
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<Car>>> GetCars()
    {
        return Ok(await carRepository.GetCarsAsync());
    }

    [HttpPost("new")]
    public async Task<ActionResult<Car>> CreateCarAsync([FromBody] CarRequestDto carRequestDto)
    {
        var userId = User.GetUserId();
        User user = await userRepository.GetUserAsync(userId);
        return Ok(await carRepository.CreateCarAsync(carRequestDto, user));
    }

    [HttpDelete("delete")]
    public async Task<ActionResult<Car>> DeleteAllCarsAsync()
    {
        if (await carRepository.DeleteCarAsync())
        {
            return Ok();
        }
        else
        {
            throw new Exception("Unable to delete the cars");
        }
    }
}
