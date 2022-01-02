using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly ILogger _logger;
        public PhotoController(ILogger<PhotoController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<FileModel> Post(IFormFile file)
        {
            try
            {
                if (file.Length == 0) 
                    throw new Exception("File is empty");
                
                var filePath = Path.Combine("wwwroot", file.FileName);
                string base64;
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    base64 = Convert.ToBase64String(stream.ToArray());
                }
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                var fileInfo = new FileModel
                {
                    Status = true,
                    OriginalName = file.FileName,
                    GeneratedName = Path.GetFileNameWithoutExtension(file.FileName),
                    Msg = "Success uploaded",
                    ImageUrl = $"data:image/jpeg;base64,{base64}"
                };
                return fileInfo;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
    public class FileModel
    {
        public bool Status { get; set; }
        public string OriginalName { get; set; }
        public string GeneratedName { get; set; }
        public string Msg { get; set; }
        public string ImageUrl { get; set; }

    }
}