using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestProj.BLL.Models;
using TestProj.BLL.Services;

namespace TestProj.BLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        [Route("Register")]
        //POST: api/Auth/Register
        public async Task<object> RegisterUser(RegisterModel model)
        {
            try
            {
                var result = await authService.CreateUser(model);
                return Ok(result);
            }
            catch
            {
                return BadRequest("Registration failed.");
            }
        }

        [HttpPost]
        [Route("Login")]
        //POST: api/Auth/Login
        public async Task<IActionResult> LoginUser(LoginModel model)
        {
            var user = await authService.FindUserByName(model);
            if(await authService.UserExists(model) && await authService.LoginValid(model))
            {
                var token = (authService.CreateJwtToken(user));
                return Ok(new { token });
            }
            else
            {
                return Unauthorized("Username or password is incorrect.");
            }
        }
    }
}