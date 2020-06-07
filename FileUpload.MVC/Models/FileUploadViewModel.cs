using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.MVC.Models
{
    public class FileUploadViewModel
    {
        public List<FileOnFileSystemModel> FilesOnFileSystem { get; set; }

        public List<FileOnDatabaseModel> FilesOnDatabase { get; set; }
    }
}
