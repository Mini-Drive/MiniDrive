using Microsoft.AspNetCore.Mvc;
using MiniDrive.App.Services;
using System.Threading.Tasks;

namespace MiniDrive.Controllers.Files
{
    [ApiController]
    [Route("api/files")]
    public class FileDeleteController : ControllerBase
    {
        private readonly FilesServices _service;

        public FileDeleteController(FilesServices service)
        {
            _service = service;
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteFileByIdAsync(id); 
            if (result == null)
            {
                return NotFound();
            }

            return NoContent(); 
        }
    }
}