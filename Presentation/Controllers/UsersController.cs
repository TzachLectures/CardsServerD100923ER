using CardsServerD100923ER.Application.Interfaces;
using CardsServerD100923ER.Core.Models;
using CardsServerD100923ER.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardsServerD100923ER.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]User user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            User? result = await _userService.Register(user);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel login)
        {
            string? result = await _userService.Login(login);
            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(result);
        }

    }
}
