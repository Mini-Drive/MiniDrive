using Microsoft.AspNetCore.Mvc;
using MiniDrive.App.Services;
using MiniDrive.Dtos;

namespace MiniDrive.Controllers.Users
{
    public class UserUpdateController : ControllerBase
    {
        private readonly UserServices _services;

        public UserUpdateController(UserServices services)
        {
            _services = services;
        }

        [HttpPut]
        [Route("api/Users/{id}")]
        public IActionResult UpdateUser([FromBody] UserDto userUpdateDto, int id)
        {
            return Ok(_services.UpdateUser(userUpdateDto, id));
        }

        [HttpDelete]
        [Route("api/Users/{id}")]
        public IActionResult DeleteUser([FromBody] UserDto userDeleteDto, int id)
        {
            return Ok(_services.DeleteUser(userDeleteDto, id));
        }
    }
}