﻿using ECommerceBackend.Application.Abstractions.Storage.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.Infrastructure.Services.Storage.Local
{
    public class LocalStorage : Storage,ILocalStorage
    {

        readonly IWebHostEnvironment _webHostEnvironment;
        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task DeleteAsync(string path, string fileName)
        
            => File.Delete($"{ path}\\{fileName}");
        

        public List<string> GetFiles(string path)
        {
            DirectoryInfo directory= new(path);
            return directory.GetFiles().Select(f=>f.Name).ToList();
        }

        public bool HasFile(string path, string fileName)
        
            =>File.Exists($"{path}\\{fileName}");
        

         async Task<bool> CopyFileAsync(string path, IFormFile file)  //path:dosya yolunu, iformfile ile ise nesnesini alacağını belirttik.
        {
            try
            {
                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path); //webrootpath bize direkt dizini getirecek. Kalan kısmı da path verecek. 
            if (!Directory.Exists(uploadPath)) //Eğer uploadpathe karşılık bir dizin yoksa oluştur diyoruz.
                Directory.CreateDirectory(uploadPath);

            List<(string fileName, string path)> datas = new();
            foreach (IFormFile file in files)
            {
                string fileNewName = await FileRenameAsync(path, file.Name, HasFile);

                await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);
                datas.Add((fileNewName, $"{path}\\{file.Name}"));  
            }

            return datas;
        }
    }
}
