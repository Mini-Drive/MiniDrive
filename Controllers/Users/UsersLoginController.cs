using Microsoft.AspNetCore.Mvc;
using MiniDrive.App.Services;
using MiniDrive.Dtos;

namespace MiniDrive.Controllers.Users
{
    [ApiController]
    public class UsersLoginController : ControllerBase
    {
        private readonly UserServices _userServices;

        public UsersLoginController(UserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpPost]
        [Route("api/Users/Login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var user = _userServices.AuthenticateUser(loginDto.Username, loginDto.Password);

            if (user != null)
            {
                // Login exitoso, incluye el ID del usuario en la respuesta
                return Ok(new { success = true, message = "Login successful", id = user.Id });
            }
            else
            {
                // Login fallido
                return BadRequest(new { success = false, message = "Invalid username or password" });
            }
        }
    }
}

