using Microsoft.AspNetCore.Mvc;
using MiniDrive.App.Services;


namespace MiniDrive.Controllers.Users
{
    public class UsersController : ControllerBase
    {
        private readonly UserServices _services;

        public UsersController(UserServices services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("api/Users")]
        public IActionResult GetAllUsers()
        {
            return Ok(_services.GetAllUsers());
        }

        [HttpGet]
        [Route("api/Users/{Id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_services.GetUserById(id));
        }
    }
}