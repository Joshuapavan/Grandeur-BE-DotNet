using System.Security.Claims;

namespace Grandeur_BE_DotNet.Extensions;

public static class ClaimsPrincipleExtension
{
    public static int GetUserId(this ClaimsPrincipal user)
    {
        return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value
        ?? throw new Exception("Cannot Identify the user, please login agaib")
        );
    }

}
