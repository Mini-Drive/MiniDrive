using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniDrive.App.Services;
using MiniDrive.Dtos;

namespace MiniDrive.Controllers.Folders
{
    public class FolderCreateController : ControllerBase
    {
        private readonly FolderServices _services;

        public FolderCreateController(FolderServices services)
        {
            _services = services;
        }

        [HttpPost]
        [Route("api/Folders")]
        public IActionResult CreateFolder([FromBody] FolderDto folderCreateDto)
        {
            return Ok(_services.CreateFolder(folderCreateDto));
        }
    }
}