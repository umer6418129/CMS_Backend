using CMS_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;

namespace CMS_Backend.Helpers
{
    public class FileManagerHelper
    {
        private readonly MyContext _dbContext;

        public FileManagerHelper(MyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public static string Upload(string basePath, string relativePath, IFormFile file, int dataId, MyContext dbContext)
        {
            string folderPath = Path.Combine(basePath, relativePath);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string imagename = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(folderPath, imagename);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            var fileRepo = new FileRepo
            {
                file_name = imagename,
                tbl_name = relativePath,
                rowId = dataId
            };

            dbContext.FileRepos.Add(fileRepo);
            dbContext.SaveChanges();

            // Return the relative path of the uploaded file
            return Path.Combine(relativePath, imagename);
        }


        public void Update(string host, string path, IFormFile file, int dataId)
        {
            // Find the existing file record in the database
            var existingFile = _dbContext.FileRepos.FirstOrDefault(f => f.tbl_name == path && f.rowId == dataId);
            if (existingFile == null)
            {
                throw new Exception("File record not found.");
            }

            // Delete the existing file from the file system
            string filePath = Path.Combine(host, path, existingFile.file_name);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // Upload the new file
            Upload(host, path, file, dataId, _dbContext);


            existingFile.file_name = filePath;
            _dbContext.SaveChanges();
        }

        public void Delete(string host, string path, int dataId)
        {
            var fileToDelete = _dbContext.FileRepos.FirstOrDefault(f => f.tbl_name == path && f.rowId == dataId);
            if (fileToDelete == null)
            {
                throw new Exception("File record not found.");
            }

            // Delete the file from the file system
            string filePath = Path.Combine(host, path, fileToDelete.file_name);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // Delete the file record from the database
            _dbContext.FileRepos.Remove(fileToDelete);
            _dbContext.SaveChanges();
        }
    }
}
