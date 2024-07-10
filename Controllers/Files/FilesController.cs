using Microsoft.AspNetCore.Mvc;
using MiniDrive.App.Services;

namespace MiniDrive.Controllers.Files
{
    public class FilesController : ControllerBase
    {
        private readonly FilesServices _service;

        public FilesController(FilesServices service)
        {
            _service = service;
        }

        //Get all files
        [HttpGet]
        [Route("api/files")]
        public IActionResult GetAllFiles()
        {
            return Ok(_service.GetAllFiles());
        }

        //Get file by id
        [HttpGet]
        [Route("api/files/{id}")]
        public IActionResult GetFileById(int id)
        {
            return Ok(_service.GetFileById(id));
        }

        //Get file by name and extension
        [HttpGet]
        [Route("api/files/byname/{name}/{extension}")]
        public IActionResult GetFileByNameAndExtension(string name, string extension)
        {
            return Ok(_service.GetFileByName(name, extension));
        }

        //Get files by folder id
        [HttpGet]
        [Route("api/files/byfolderid/{folderId}")]
        public IActionResult GetFilesByFolderId(int folderId)
        {
            return Ok(_service.GetFilesByFolderId(folderId));
        }

        //Get all files by user id
        [HttpGet]
        [Route("api/files/byuserid/{userId}")]
        public IActionResult GetFilesByUserId(int userId)
        {
            return Ok(_service.GetFilesByUserId(userId));
        }

        //Get all files by folder id and user id
        [HttpGet]
        [Route("api/files/byfolderidanduserid/{userId}/{folderId}")]
        public IActionResult GetFilesByUserIdAndFolderId(int userId, int folderId)
        {
            return Ok(_service.GetFilesByUserIdAndFolderId(userId, folderId));
        }
    }
}