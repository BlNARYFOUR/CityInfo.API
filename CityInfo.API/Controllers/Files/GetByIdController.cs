using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.API.Controllers.Files
{
    [Route("api/files/{id}")]
    [ApiController]
    public class GetByIdController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider) : ControllerBase {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider
            ?? throw new System.ArgumentNullException(nameof(fileExtensionContentTypeProvider));

        [HttpGet]
        public ActionResult GetFile(int id)
        {
            string[] paths = Directory.GetFiles("Assets/", "file-" + id.ToString("000") + ".*");

            if (0 == paths.Length)
            {
                return NotFound();
            }

            string path = paths[0];

            if (!_fileExtensionContentTypeProvider.TryGetContentType(path, out string? contentType))
            {
                contentType = "application/octet-stream";
            }

            return File(System.IO.File.ReadAllBytes(path), contentType, Path.GetFileName(path));
        }
    }
}
