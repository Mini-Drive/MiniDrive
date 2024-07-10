using Microsoft.AspNetCore.Mvc;
using MiniDrive.Infrastructure.Contexts;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using MiniDrive.Dtos;
using Microsoft.AspNetCore.Authentication;

namespace MiniDrive.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly MiniDriveContext _context;
        public AuthController(MiniDriveContext context)
        {
            _context = context;
        }
    [HttpPost]
    public async Task<IActionResult> login([FromBody] AuthResponse authResponse)
        {
            var user_auth = _context.Users.FirstOrDefault(u => u.UserName == authResponse.UserName && u.Password == authResponse.Password);

            if (user_auth == null)
            {
                return BadRequest("The user or password isn't valid");
            }
            else
            {
                var secret_key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("3C7A6C4E2754B9A31F225E201C02D82E"));
                var signin_credentials = new SigningCredentials(secret_key, SecurityAlgorithms.HmacSha256);
                var token_options = new JwtSecurityToken(
                    issuer: @Environment.GetEnvironmentVariable("JWTURL"),
                    audience: @Environment.GetEnvironmentVariable("JWTURL"),
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: signin_credentials
                );
                var token_write = new JwtSecurityTokenHandler().WriteToken(token_options);

                return Ok(new { Token = token_write });
            }
            return Unauthorized();
        }
    }
}