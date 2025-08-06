using Grandeur_BE_DotNet.DTO;
using Grandeur_BE_DotNet.Extensions;
using Grandeur_BE_DotNet.Models.Entitiles;
using Grandeur_BE_DotNet.Repositories;
using Grandeur_BE_DotNet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Grandeur_BE_DotNet.Controllers;

public class CarsController(ICarRepository carRepository, IUserRepository userRepository, IPhotoService photoService) : ControllerBase
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

    [HttpPost("add-photo")]
    public async Task<ActionResult<PhotoDto>> AddPhoto(IFormFile file)
    {
        var user = await userRepository.GetUserAsync(User.GetUserId());
        if (user == null) return BadRequest("Cannot update the user.");

        var result = await photoService.AddPhotoAsync(file);
        if (result.Error != null) return BadRequest(result.Error.Message);

        var photo = new Photo
        {
            Url = result.SecureUrl.AbsoluteUri,
            PublicId = result.PublicId
        };

        // if (car.Photos.Count == 0) photo.IsMain = true;

        // user.Photos.Add(photo);

        // if (await userRepository.SaveAllAsync())
        //     return CreatedAtAction(
        //             nameof(GetUserByUsername),
        //             new { username = user.UserName },
        //             mapper.Map<PhotoDto>(photo)
        //             );
        return BadRequest("Error adding photo");
    }
}
