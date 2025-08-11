using Grandeur_BE_DotNet.Models.Entitiles;

namespace Grandeur_BE_DotNet.Services;

public interface ITokenService
{
    String CreateToken(User user);
}
