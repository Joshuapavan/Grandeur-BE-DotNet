using System;
using Grandeur_BE_DotNet.Data;
using Grandeur_BE_DotNet.Models.Entitiles;
using Microsoft.EntityFrameworkCore;

namespace Grandeur_BE_DotNet.Repositories.Implementation;

public class CarRepository(AppDbContext context) : ICarRepository
{
    public async Task<IEnumerable<Car>> GetCarsAsync()
    {
        return await context.Cars.ToListAsync();
    }
}
