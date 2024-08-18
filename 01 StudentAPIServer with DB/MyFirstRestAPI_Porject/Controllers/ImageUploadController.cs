using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentApi.Controllers
{
    [Route("api/ImageUpload")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        [HttpPost("Upload")]
        public async Task<IActionResult> UploadImage(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0) return BadRequest("No File Uploaded");
            var uploadDirectory = @"C:\MyUpload";
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var filePath = Path.Combine(uploadDirectory, fileName);

            if (!Directory.Exists(uploadDirectory))
                Directory.CreateDirectory(uploadDirectory);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }
            return Ok(new { filePath });
        }

        [HttpGet("getImage/{fileName}")]
        public IActionResult GetImage(string fileName)
        {
            var uploadDirectory = @"C:\MyUpload";
            var filePath = Path.Combine(uploadDirectory, fileName);

            if (!System.IO.File.Exists(filePath))
                return NotFound("Image Not Found");

            var image = System.IO.File.OpenRead(filePath);
            var mimeType = GetMimeType(filePath);


            return File(image, mimeType);
        }

        private string GetMimeType(string filePath)
        {
            var extn = Path.GetExtension(filePath).ToLowerInvariant();

            return extn switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
               _ => "application/octet-stream",

            };

        }

    }
}
