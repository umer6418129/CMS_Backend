using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace CMS_Backend.Helpers
{
    public class FileManagerHelper
    {
        public static string imagename;

        public static void Create(string host, string path, IFormFile file)
        {
            string folderPath = Path.Combine(host, path);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            imagename = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(folderPath, imagename);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }
    }
}
