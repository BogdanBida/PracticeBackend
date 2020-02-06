using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestProj.BLL.Services;

namespace TestProj.BLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //GET: /api/UserProfile
    public class UserProfileController : ControllerBase
    {
        private readonly IAuthService authService;

        public UserProfileController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpGet]
        [Authorize]
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "Id").Value;
            var user = await authService.FindUserById(userId);
            return new
            {
                user.UserName,
                user.FullName,
                user.Email,
            };
        }
    }
}