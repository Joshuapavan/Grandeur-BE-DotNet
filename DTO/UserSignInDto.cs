using System;

namespace Grandeur_BE_DotNet.DTO;

public class UserSignInDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}
