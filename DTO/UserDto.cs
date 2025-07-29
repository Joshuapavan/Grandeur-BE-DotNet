using System;

namespace Grandeur_BE_DotNet.DTO;

public class UserDto
{
    public required string Email { get; set; }
    public required string Token { get; set; }
}
