using Microsoft.AspNetCore.Mvc;
using MiniDrive.App.Interfaces;
using MiniDrive.App.Services;
using MiniDrive.Models;

namespace MiniDrive.Controllers
{
    [ApiController]
    public class UsersCreateController : ControllerBase
    {
        private readonly IUsers _users;

        public UsersCreateController(IUsers users)
        {
            _users = users;
        }

        [HttpPost]

        public async Task<IActionResult> CreateUser(User user)
        {
     
            
                _users.CreateUser(user);
                return Ok(user);


        }
    }
}