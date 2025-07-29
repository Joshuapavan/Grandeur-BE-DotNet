using System;

namespace Grandeur_BE_DotNet.Models.Entitiles;

public class User
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public bool Verifed { get; set; } = false;
    public bool IsBlocked { get; set; } = false;

    // Time Stamps
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
