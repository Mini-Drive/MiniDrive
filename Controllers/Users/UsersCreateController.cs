using Microsoft.AspNetCore.Mvc;
using MiniDrive.App.Services;
using MiniDrive.Dtos;

namespace MiniDrive.Controllers.Users
{
    [ApiController]
    public class UsersCreateController : ControllerBase
    {
        private readonly UserServices _services;

        public UsersCreateController(UserServices services)
        {
            _services = services;
        }

      [HttpPost]
[Route("api/Users/Register")]
public IActionResult CreateUser([FromBody] UserDto userDto)
{
    try
    {
        var user = _services.CreateUser(userDto);
        if (user != null)
        {
            return Ok(new { success = true, message = "User registered successfully" });
        }
        else
        {
            return BadRequest(new { success = false, message = "User registration failed" });
        }
    }
    catch (Exception ex)
    {
        return StatusCode(500, new { success = false, message = "Internal server error", details = ex.Message });
    }
}

    }
}


