using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.API.Controllers.Files
{
    [Route("api/files/{id}")]
    [ApiController]
    [Tags("Files")]
    public class GetByIdController(FileExtensionContentTypeProvider fectProvider) : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _fectProvider = fectProvider ?? throw new System.ArgumentNullException(nameof(fectProvider));

        [HttpGet(Name = "GetFile")]
        public ActionResult GetFile(int id)
        {
            string[] paths = Directory.GetFiles("assets/files/", $"file-{id:000}.*");

            if (0 == paths.Length)
            {
                return NotFound();
            }

            string path = paths[0];

            if (!_fectProvider.TryGetContentType(path, out string? contentType))
            {
                contentType = "application/octet-stream";
            }

            return File(System.IO.File.ReadAllBytes(path), contentType, Path.GetFileName(path));
        }
    }
}
