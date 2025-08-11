namespace Grandeur_BE_DotNet.DTO;

public class CarRequestDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Model { get; set; }
    public required string Brand { get; set; }
    public required string CarNumber { get; set; }
    public required string YearOfManufacture { get; set; }
    public required string KmsDriven { get; set; }
    public required string Price { get; set; }
    public required string AnyDamages { get; set; }
    public required string NoOfOwners { get; set; }
    public bool Insured { get; set; }
}
