using Grandeur_BE_DotNet.DTO;
using Grandeur_BE_DotNet.Models.Entitiles;

namespace Grandeur_BE_DotNet.Repositories;

public interface ICarRepository
{
    Task<IEnumerable<Car>> GetCarsAsync();

    Task<Car> CreateCarAsync(CarRequestDto carRequest, User user);

    Task<IEnumerable<Car>> SearchCarAsync(string searchTerm);
    Task<bool> DeleteCarAsync();

}
