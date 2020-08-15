using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;

namespace WebApplication1.Services
{
    public interface IBlobService
    {

        public Task<BlobInfo> GetBlobAsync(string name);
        public Task<IEnumerable<string>> ListBlobAsync();
        public Task UploadFileBlobAsync(string filePath, string fileName);
        public Task UploadContentBlobAsync(string content, string fileName);
        public Task DeleteBlobAsync(string blobName);
    }
}
