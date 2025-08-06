using System;
using Grandeur_BE_DotNet.Models.Entitiles;

namespace Grandeur_BE_DotNet.Repositories;

public interface ICarRepository
{
    Task<IEnumerable<Car>> GetCarsAsync();
}
