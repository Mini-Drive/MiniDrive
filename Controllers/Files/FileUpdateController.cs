using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniDrive.App.Services;
using MiniDrive.Dtos;

namespace MiniDrive.Controllers.Files
{
    public class FileUpdateController : ControllerBase
    {
          private readonly FilesServices _service;

        public FileUpdateController(FilesServices service)
        {
            _service = service;
        }

        //Update a file
        [HttpPut]
        [Route("api/files/{id}")]
        public IActionResult UpdateFile(int id, [FromBody] FileDto model)
        {
            return Ok(_service.UpdateFile(model, id));
        }
    }
}