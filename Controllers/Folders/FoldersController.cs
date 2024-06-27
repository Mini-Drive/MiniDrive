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
        [Route("api/Folders/Byid/{Id}")]
        public IActionResult GetFolderById(int id)
        {
            return Ok(_services.GetFolderById(id));
        }

        [HttpGet]
        [Route("api/Folders/Byparent/{parentId}")]
        public IActionResult GetFoldersByParentFolderID(int parentFolderID)
        {
            return Ok(_services.GetFoldersByParentFolderID(parentFolderID));
        }

        [HttpGet]
        [Route("api/Folders/")]
        public IActionResult GetFoldersByUserId(int userId)
        {
            return Ok(_services.GetFoldersByUserId(userId));
        }


    }
}