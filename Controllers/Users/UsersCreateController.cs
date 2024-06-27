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
        [Route("api/Users")]
        public IActionResult CreateUser([FromBody] UserDto userDto)
        {
            return Ok(_services.CreateUser(userDto));
        }

    }
}