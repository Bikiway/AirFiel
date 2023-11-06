using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AirFiel_Mariana_Oliveira.Helpers
{
    public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile imageFile, string folder);

        Task<string> LoadImagesAsync(string imageFromFile, string folder);
    }
}
