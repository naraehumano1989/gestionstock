using GestionDeStock.Application.Common;
using GestionDeStock.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeStock.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IToken _tokenService;
        private readonly IUser _userService; 

        public AuthController(IToken tokenService, IUser userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserEntity request)
        {
            var user = await _userService.ValidateUserAsync(request.Username, request.Password);
            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            var token = _tokenService.GenerateToken(user);

            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserEntity request)
        {
            var user = await _userService.CreateUser(request);
            return Ok(user);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int userId)
        {
            var user = await _userService.DeleteUser(userId);
            return Ok(user);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }
    }
}
