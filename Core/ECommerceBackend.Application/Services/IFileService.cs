﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.Application.Services
{
    public interface IFileService
    {
        Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files); //Yükle
        Task<string> FileRenameAsync(string fileName); //Adlandır
        Task<bool> CopyFileAsync(string path, IFormFile file); //Kaydet

    }

}
