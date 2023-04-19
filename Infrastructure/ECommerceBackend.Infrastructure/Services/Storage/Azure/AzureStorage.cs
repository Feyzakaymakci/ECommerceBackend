﻿using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ECommerceBackend.Application.Abstractions.Storage.Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.Infrastructure.Services.Storage.Azure
{
    public class AzureStorage : IAzureStorage
    {
        readonly BlobServiceClient _blobServiceClient;
        BlobContainerClient _blobContainerClient;
        public AzureStorage(IConfiguration configuration)
        {
            _blobServiceClient = new (configuration["Storage:Azure"]); //appsetting.json daki connection stringi burada belirtiyoruz.
        }
        public Task DeleteAsync(string containerName, string fileName)
        {
            throw new NotImplementedException();
        }

        public List<string> GetFiles(string containerName)
        {
            throw new NotImplementedException();
        }

        public bool HasFile(string containerName, string fileName)
        {
            throw new NotImplementedException();
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string containerName, IFormFileCollection files)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await _blobContainerClient.CreateIfNotExistsAsync(); //İlgili container var mı yok mu?
            await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer); ////Blob erişim izni olarak PublicAccessType seçiyoruz bu sayede herkese açık hale getiriyoruz.

            List<(string fileName,string pathOrContainerName)> datas = new();
            foreach (IFormFile file in files)
            {
               BlobClient blobClient= _blobContainerClient.GetBlobClient(file.Name);
                 await blobClient.UploadAsync(file.OpenReadStream()); //Stream e çevirdik.
                datas.Add((file.Name,containerName));
            }
            return datas;
        }
    }
}