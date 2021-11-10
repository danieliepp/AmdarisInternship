using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MovieZone.API.Models;
using MovieZone.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Services.Implementations
{
    public class StorageService : IStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IConfiguration _configuration;
        private readonly string containerName;
        private readonly BlobContainerClient containerClient;
        public StorageService(BlobServiceClient blobServiceClient, IConfiguration configuration)
        {
            _blobServiceClient = blobServiceClient;
            _configuration = configuration;
            containerName = _configuration.GetSection("Storage:ContainerName").Value;
            containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        }
        public void DeleteFile(string uniqueFileIdentifier)
        {
            containerClient.GetBlobClient(uniqueFileIdentifier).DeleteIfExists();
        }
        public string Upload(FileImage file)
        {
            DeleteFile(file.Id.ToString());
            var blobClient = containerClient.GetBlobClient(file.Id.ToString());
            using var stream = file.FormFile.OpenReadStream();
            blobClient.Upload(stream, true);

            return blobClient.Uri.AbsoluteUri;
        }

        public string GetPoster(int id)
        {
            return containerClient.GetBlobClient(id.ToString()).Uri.AbsoluteUri;
        }
    }
}
