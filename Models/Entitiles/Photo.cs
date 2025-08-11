using System.ComponentModel.DataAnnotations.Schema;

namespace Grandeur_BE_DotNet.Models.Entitiles;

[Table("Photos")]
public class Photo
{
    public int Id { get; set; }
    public required String Url { get; set; }
    public string? PublicId { get; set; }

    // Navigation properities

    public int CarId { get; set; }
    public Car Car { get; set; } = null!;
}
