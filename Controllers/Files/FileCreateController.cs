using Microsoft.AspNetCore.Mvc;
using MiniDrive.App.Services;
using MiniDrive.Dtos;

namespace MiniDrive.Controllers.Files
{
    public class FileCreateController : ControllerBase
    {
        private readonly FilesServices _service;

        public FileCreateController(FilesServices service)
        {
            _service = service;
        }

        //Post Create a new file
        [HttpPost]
        [Route("api/files")]
        public async Task<IActionResult> Create([FromBody] FileDto model)
        {
            return Ok(await _service.CreateFile(model));
        }

    }
}