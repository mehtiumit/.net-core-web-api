using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AzureStorageLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/blobs")]
    public class BlobExplorerController : Controller
    {
        private readonly IBlobStorage _blobStorage;

        public BlobExplorerController(IBlobStorage blobStorage)
        {
            _blobStorage = blobStorage;
        }

        [HttpGet("getallblobs")]
        public IActionResult GetAllBlobs()
        {

            var names = _blobStorage.GetNames(EContainerName.pictures);
            var blobUrl = $"{_blobStorage.BlobUrl}/{EContainerName.pictures.ToString()}";
            names.Select(x => new FileBlob
            {
                Name = x,
                Url = $"{blobUrl}/{x}"
            }).ToList();

            return Ok(blobUrl);
        }

        [HttpPost("uploadimage")]
        public async Task<IActionResult> UploadImage([FromQuery] IFormFile picture)

        {
            await _blobStorage.SetLogAsync("Upload image kısmına girildi.", "logs.txt");
            var newFilename = Guid.NewGuid().ToString() + Path.GetExtension(picture.FileName);
            await _blobStorage.UploadAsync(picture.OpenReadStream(), newFilename, EContainerName.pictures);
            await _blobStorage.SetLogAsync("Upload image kısmından çıkış yapıldı.", "logs.txt");
            return Ok();

        }

        [HttpGet("downloadimage")]
        public async Task<IActionResult> DownloadImage([FromQuery] string fileName)
        {
            await _blobStorage.GetLogAsync("logs.txt");
            var stream = await _blobStorage.DownloadAsync(fileName, EContainerName.pictures);
            return File(stream, "application/octet-stream", fileName);
        }
    }
}
