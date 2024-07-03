using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniDrive.App.Services;
using MiniDrive.Dtos;

namespace MiniDrive.Controllers.Folders
{  
    public class FolderUpdateController : ControllerBase
    {
         private readonly FolderServices _services;

        public FolderUpdateController(FolderServices services)
        {
            _services = services;
        }

        [HttpPut]
        [Route("api/Folders/{id}")]
        public IActionResult UpdateFolder([FromBody] FolderDto folderUpdateDto, int id)
        {
            return Ok(_services.UpdateFolder(folderUpdateDto, id));
        }

        [HttpDelete]
        [Route("api/Folders/{id}")]
        public IActionResult DeleteFolder([FromBody] FolderDto folderDeleteDto, int id)
        {
            return Ok(_services.DeleteFolder(id));
        }
    }
}