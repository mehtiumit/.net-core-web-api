using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace AzureStorageLibrary.Services
{
    public class BlobStorage : IBlobStorage
    {
        private BlobServiceClient _blobServiceClient;

        public BlobStorage()
        {
            _blobServiceClient = new BlobServiceClient(ConnectionString.AzureStorageConnectionString);
        }

        public string BlobUrl => "https//cloudogrenme.blob.core.windows.net";
        public async Task UploadAsync(Stream fileStream, string fileName, EContainerName eContainerName)
        {

            var containerClient = _blobServiceClient.GetBlobContainerClient(eContainerName.ToString());
            await containerClient.CreateIfNotExistsAsync();
            await containerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(fileStream);

        }


        public async Task<Stream> DownloadAsync(string fileName, EContainerName eContainerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(eContainerName.ToString());
            var blobClient = containerClient.GetBlobClient(fileName);
            var info = await blobClient.DownloadAsync();
            return info.Value.Content;
        }

        public async Task DeleteAsync(string fileName, EContainerName eContainerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(eContainerName.ToString());
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.DeleteAsync();
        }

        public async Task SetLogAsync(string text, string fileName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(EContainerName.logs.ToString());
            

            var appendBlobClient = containerClient.GetAppendBlobClient(fileName);

            

            await appendBlobClient.CreateIfNotExistsAsync();

            await using (MemoryStream ms = new MemoryStream())
            {
                await using (StreamWriter streamWriter = new StreamWriter(ms))
                {
                    await streamWriter.WriteAsync($"{DateTime.Now}:{text}\n");
                    await streamWriter.FlushAsync();
                    await appendBlobClient.AppendBlockAsync(ms);

                }
            }

        }

        public async Task<List<string>> GetLogAsync(string fileName)
        {
            List<string> logs = new List<string>();
            var containerClient = _blobServiceClient.GetBlobContainerClient(EContainerName.logs.ToString());

            var appendBlobClient = containerClient.GetAppendBlobClient(fileName);

            await appendBlobClient.CreateIfNotExistsAsync();

            var info = await appendBlobClient.DownloadAsync();

            using (StreamReader sr = new StreamReader(info.Value.Content))
            {
                string line = string.Empty;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    logs.Add(line);
                }
            }

            return logs;


        }

        public List<string> GetNames(EContainerName eContainerName)
        {
            List<string> blobNames = new List<string>();
            var containerClient = _blobServiceClient.GetBlobContainerClient(eContainerName.ToString());

            var blobs = containerClient.GetBlobs();
            blobs.ToList().ForEach(x =>
            {
                blobNames.Add(x.Name);
            });
            return blobNames;
        }
    }
}
