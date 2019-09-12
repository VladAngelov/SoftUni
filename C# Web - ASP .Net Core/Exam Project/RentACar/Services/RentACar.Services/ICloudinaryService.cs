using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace RentACar.Services
{
    public interface ICloudinaryService
    {
        Task<string> UploadPictureAsync(IFormFile pictureFile, string fileName);
    }
}