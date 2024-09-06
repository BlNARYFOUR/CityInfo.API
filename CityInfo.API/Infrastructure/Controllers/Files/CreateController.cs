using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Infrastructure.Controllers.Files
{
    [Route("api/files")]
    [ApiController]
    [Tags("Files")]
    public class CreateController(IWebHostEnvironment webHostEnvironment) : ControllerBase
    {
        private static int _id = 1;
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;
        private readonly string[][] _contentTypes = [
            ["application/pdf", "pdf"],
            ["text/plain", "txt"],
        ];

        [HttpPost]
        public async Task<ActionResult> CreateFile(IFormFile file)
        {
            string[]? contentType = _contentTypes.FirstOrDefault(c => c[0] == file.ContentType);

            if (0 == file.Length || 20971520 < file.Length || null == contentType)
            {
                return BadRequest($"No or invalid file given: {file.ContentType}.");
            }

            string path = Path.Combine(_webHostEnvironment.ContentRootPath, "assets/files/", $"file-{++_id:000}.{contentType[1]}");

            using FileStream stream = new(path, FileMode.Create);
            await file.CopyToAsync(stream);

            return CreatedAtRoute("GetFile", new { id = _id }, new { message = "File uploaded successfully" });
        }
    }
}
