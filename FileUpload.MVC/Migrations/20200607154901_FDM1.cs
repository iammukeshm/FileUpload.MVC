using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FileUpload.MVC.Migrations
{
    public partial class FDM1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FileOnDatabaseModel",
                table: "FileOnDatabaseModel");

            migrationBuilder.RenameTable(
                name: "FileOnDatabaseModel",
                newName: "FilesOnDatabase");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilesOnDatabase",
                table: "FilesOnDatabase",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FilesOnFileSystem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    FileType = table.Column<string>(nullable: true),
                    Extension = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UploadedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    FilePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesOnFileSystem", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilesOnFileSystem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilesOnDatabase",
                table: "FilesOnDatabase");

            migrationBuilder.RenameTable(
                name: "FilesOnDatabase",
                newName: "FileOnDatabaseModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileOnDatabaseModel",
                table: "FileOnDatabaseModel",
                column: "Id");
        }
    }
}
