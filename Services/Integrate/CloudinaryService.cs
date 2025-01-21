using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using PetManagementAPI.Models;
using System.Net;

namespace PetManagementAPI.Services.Integrate
{
    public class CloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
        }

        public async Task<string> UploadImage(IFormFile image, string folder)
        {
            using var stream = image.OpenReadStream();
            string fileName = Guid.NewGuid().ToString();

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(fileName, stream),
                Folder = folder
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Failed to upload image: {uploadResult.Error.Message}");
            }

            return uploadResult.SecureUrl.ToString();
        }
    }
}
