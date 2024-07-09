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

        [HttpDelete]
        [Route("api/files/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteFileByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpGet]
        [Route("api/files/deleted/{userId}")]
        public IActionResult GetDeletedFilesByUserId(int userId)
        {
            var files = _service.GetInactiveFilesByUserId(userId);
            if (files == null || !files.Any())
            {
                return NotFound();
            }

            return Ok(files);
        }
    }
}


