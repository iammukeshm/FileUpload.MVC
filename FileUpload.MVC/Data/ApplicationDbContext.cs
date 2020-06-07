using FileUpload.MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<FileOnDatabaseModel> FilesOnDatabase { get; set; }
        public DbSet<FileOnFileSystemModel> FilesOnFileSystem { get; set; }
    }
}
