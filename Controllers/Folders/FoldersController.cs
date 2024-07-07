using Microsoft.AspNetCore.Mvc;
using MiniDrive.App.Services;

namespace MiniDrive.Controllers.Folders
{
    public class FoldersController : ControllerBase
    {
        private readonly FolderServices _services;

        public FoldersController(FolderServices services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("api/Folders")]
        public IActionResult GetAllFolders()
        {
            return Ok(_services.GetAllFolders());
        }

        [HttpGet]
        [Route("api/Folders/Byname/{folderName}")]
        public IActionResult GetFolderByFolderName(string folderName)
        {
            return Ok(_services.GetFolderByFolderName(folderName));
        }

        [HttpGet]
        [Route("api/Folders/Byid/{id}")]
        public IActionResult GetFolderById(int id)
        {
            return Ok(_services.GetFolderById(id));
        }

        [HttpGet]
        [Route("api/Folders/Byparent/{parentId}")]
        public IActionResult GetFoldersByParentFolderID(int parentId)
        {
            return Ok(_services.GetFoldersByParentFolderID(parentId));
        }

        [HttpGet]
        [Route("api/Folders/{userId}")]
        public IActionResult GetFoldersByUserId(int userId)
        {
            return Ok(_services.GetFoldersByUserId(userId));
        }
        
        //get index folder
        [HttpGet]
        [Route("api/Folders/index/{userId}")]
        public IActionResult GetIndexFolderByUserId(int userId)
        {
            return Ok(_services.GetIndexFolderByUserId(userId));
        }

    }
}