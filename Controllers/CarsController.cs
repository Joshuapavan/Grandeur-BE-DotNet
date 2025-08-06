using Grandeur_BE_DotNet.Models.Entitiles;
using Grandeur_BE_DotNet.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Grandeur_BE_DotNet.Controllers;

public class CarsController(ICarRepository carRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Car>> GetCars()
    {
        return await carRepository.GetCarsAsync();
    }
}
