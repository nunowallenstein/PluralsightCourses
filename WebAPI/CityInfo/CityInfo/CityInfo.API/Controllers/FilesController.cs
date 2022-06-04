using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
namespace CityInfo.API.Controllers
{
    [Route("api/files")]
    [Authorize]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider ??
                throw new ArgumentException(nameof(fileExtensionContentTypeProvider));

        }


        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            string path = "getting-started-with-rest-slides.pdf";
            if (!System.IO.File.Exists(path))
                return NotFound();
            if (!_fileExtensionContentTypeProvider.TryGetContentType(path, out var contentType))
                contentType = "application/octet-stream";

            var bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, contentType, Path.GetFileName(path));

        }


    }
}
