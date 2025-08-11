using CloudinaryDotNet.Actions;

namespace Grandeur_BE_DotNet.Services;

public interface IPhotoService
{
    Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
}
