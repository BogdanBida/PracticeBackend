using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestProj.Models;

namespace TestProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //GET: /api/UserProfile
    public class UserProfileController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;

        public UserProfileController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "Id").Value;
            var user = await userManager.FindByIdAsync(userId);
            return new
            {
                user.UserName,
                user.FullName,
                user.Email,
            };
        }
    }
}