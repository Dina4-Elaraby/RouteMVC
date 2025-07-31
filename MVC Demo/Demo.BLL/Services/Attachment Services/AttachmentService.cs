using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services.Attachment_Services
{
    public class AttachmentService : IAttachmentService
    {
        public string? Upload(IFormFile file, string folderName)
        {
            //allowed Extenstions for upload file
            List<string> allowedExtenstions = [".jpg",".png",".jpeg"];

            // maximum size of upload file
            const int maxSize = 2097152;

            //1.Check Extension
            var extenstion = Path.GetExtension(file.FileName); // get extension from file make split and get last part 
            if (!allowedExtenstions.Contains(extenstion)) return null; // return null in db

            //2.Check Size
            if (file.Length == 0 || file.Length > maxSize) return null;

            //3.Get Located Folder Path
            //var locatedFolderPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\files\\{folderName}";
            var locatedFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName);

            //4.Make Attachment Name Unique-- GUID
            var fileNameUnique = $"{Guid.NewGuid()}{file.FileName}";

            //5.Get File Path
            var filePath = Path.Combine(locatedFolderPath, fileNameUnique);

            //6.Create File Stream To Copy File[Unmanaged]
            using FileStream fileStream = new FileStream(filePath, FileMode.Create);// open stream and close using 'using'

            //7.Use Stream To Copy File
            file.CopyTo(fileStream);
            //8.Return FileName To Store In Database
            return fileNameUnique;

        }

        public bool Delete(string filePath)
        {
            // 1.Get File Path
            if (!File.Exists(filePath)) return false;

            //2.Check if File Exists Or Not If Exists Remove It
            else
                File.Delete(filePath);
            return true;

        }
    }
}
