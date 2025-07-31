using System;

namespace Grandeur_BE_DotNet.Models.Entitiles;

public class Car
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Model { get; set; }
    public required string CarNumber { get; set; }
    public required string YearOfManufacture { get; set; }
    public required string KmsDriven { get; set; }
    public required string Price { get; set; }
    public required string AnyDamages { get; set; }
    public required string NoOfOwners { get; set; }
    public bool Insured { get; set; } = false;

    // Navigational Props
    public required int UserId { get; set; }

}
