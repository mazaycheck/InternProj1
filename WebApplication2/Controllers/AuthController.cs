using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data.Dtos;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]UserLoginDto userLoginDto)
        {
         
            if(!ModelState.IsValid)
            { return BadRequest(ModelState); }
            var user = await _authService.Login(userLoginDto.Email, userLoginDto.Password);
            if(user != null)
            {
                var token = _authService.CreateToken(user);                
                return Ok(new { token = token });
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]UserRegisterDto userRegisterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int id = await _authService.Register(userRegisterDto);

            if (id != default)
            {
                return CreatedAtAction("GetUser","Users", new { id = id }, id);
            }
            else
            {
                return Problem("Could not register");
            }
        }

        
    }
}
