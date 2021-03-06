﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorageLibrary
{
    public enum EContainerName
    {
        pictures,
        pdf,
        logs
    }
    public interface IBlobStorage
    {
        public string BlobUrl { get; }
        Task UploadAsync(Stream fileStream, string fileName, EContainerName eContainerName);
        Task<Stream> DownloadAsync(string fileName, EContainerName eContainerName);
        Task DeleteAsync(string fileName, EContainerName containerName);
        Task SetLogAsync(string text, string fileName);

        Task<List<string>> GetLogAsync(string fileName);
       
        //links
        List<string> GetNames(EContainerName eContainerName);

    }
}
