using System.IO;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AirFiel_Mariana_Oliveira.Helpers
{
    public class ImageHelper : IImageHelper
    {
        public async Task<string> UploadImageAsync(IFormFile imageFile, string folder)
        {
            string guid = Guid.NewGuid().ToString(); //Gera uma chave aleatória
            string file = $"{guid}.jpg";

            string path = Path.Combine(
                 Directory.GetCurrentDirectory(),
                 $"wwwroot\\images\\{folder}",
                 file);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }
            return $"~/images/{folder}/{file}";
        }
    }
}
