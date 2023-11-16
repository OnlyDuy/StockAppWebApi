using Microsoft.AspNetCore.Mvc;
using StockAppWebApiVS.Models;
using StockAppWebApiVS.Services;
using StockAppWebApiVS.ViewModels;

namespace StockAppWebApiVS.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // https://localhost:port/api/User/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            try
            {
                User? user = await _userService.Register(registerViewModel);
                return Ok(user);
            } 
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // https://localhost:port/api/User/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            try
            {
                string jwtToken = await _userService.Login(loginViewModel);
                return Ok(new { jwtToken});
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

    }
}
