using AutoMapper;
using Grandeur_BE_DotNet.Data;
using Grandeur_BE_DotNet.DTO;
using Grandeur_BE_DotNet.Models.Entitiles;
using Microsoft.EntityFrameworkCore;

namespace Grandeur_BE_DotNet.Repositories.Implementation;

public class CarRepository(AppDbContext context, IMapper mapper) : ICarRepository
{
    public async Task<Car> CreateCarAsync(CarRequestDto carRequest, User user)
    {
        var car = mapper.Map<Car>(carRequest);
        car.User = user;
        car.UserId = user.Id;
        var result = context.Cars.Add(car) ?? throw new Exception("Unable to add the car");
        await context.SaveChangesAsync();
        return car;
    }

    public async Task<bool> DeleteCarAsync()
    {
        var cars = await context.Cars.ToListAsync();
        await context.Database.ExecuteSqlRawAsync("DELETE FROM Cars");
        return true;
    }

    public async Task<IEnumerable<Car>> GetCarsAsync()
    {
        return await context.Cars.ToListAsync();
    }

    public async Task<IEnumerable<Car>> SearchCarAsync(string searchTerm)
    {
        var cars = await context.Cars
        .Where(car =>
                    car.Name.ToLower().Contains(searchTerm.ToLower()) ||
                    car.Brand.ToLower().Contains(searchTerm.ToLower()) ||
                    car.Model.ToLower().Contains(searchTerm.ToLower())
        )
        .ToListAsync();

        return cars;
    }
}
