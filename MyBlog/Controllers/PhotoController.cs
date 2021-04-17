using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBlog.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                if (file.Length == 0) throw new Exception("File is empty");
                string filePath = Path.Combine("wwwroot", file.FileName);
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
                var rootPath = Path.GetFullPath(filePath);
                /*                $"data:image/{file.FileName.Split('.')[1]},{base64}"
                */
                var fileInfo = new FileModel
                {
                    Status = true,
                    OriginalName = file.FileName,
                    GeneratedName = Path.GetFileNameWithoutExtension(file.FileName),
                    Msg = "Succes uploaded",
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