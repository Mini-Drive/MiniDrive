using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniDrive.App.Services;
using MiniDrive.Dtos;

namespace MiniDrive.Controllers.Files
{
    public class FileDeleteController : ControllerBase
    {
          private readonly FilesServices _service;

        public FileDeleteController(FilesServices service)
        {
            _service = service;
        }


        //Delete a file
        [HttpDelete]
        [Route("api/files/{id}")]
        public IActionResult DeleteFile(int id)
        {
            var file = _service.DeleteFile(id);
            return Ok(file);
        }

    }
}