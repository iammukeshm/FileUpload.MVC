using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FileUpload.MVC.Data;
using FileUpload.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.MVC.Controllers
{
    public class FileUploadController : Controller
    {
        private readonly ApplicationDbContext context;

        public FileUploadController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadToFileSystem(List<IFormFile> files)
        {
            foreach(var file in files)
            {
                var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\Files\\");
                bool basePathExists = System.IO.Directory.Exists(basePath);
                if (!basePathExists) Directory.CreateDirectory(basePath);
                var filePath = Path.Combine(basePath, file.FileName);
                using(var stream = new FileStream(filePath,FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            ViewBag.Message = "File successfully uploaded";
            return View("~/Views/FileUpload/Index.cshtml");
        }
        [HttpPost]
        public async Task<IActionResult> UploadToDatabase(List<IFormFile> files)
        {
            foreach (var file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var extension = Path.GetExtension(file.FileName);
                var fileModel = new FileModel
                {
                    CreatedOn = DateTime.UtcNow,
                    FileType = file.ContentType,
                    Extension = extension,
                    Name = fileName
                };
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    fileModel.Data = dataStream.ToArray();
                }
                context.Files.Add(fileModel);
                context.SaveChanges();
            }
            ViewBag.Message = "File successfully uploaded to Database";
            return View("~/Views/FileUpload/Index.cshtml");
        }
    }
}