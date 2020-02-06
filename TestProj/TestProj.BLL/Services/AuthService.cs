using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TestProj.BLL.Constants;
using TestProj.BLL.Models;
using TestProj.DAL.Entities;

namespace TestProj.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly AppSettings appSettings;

        public AuthService(UserManager<AppUser> userManager, IOptions<AppSettings> appSettings)
        {
            this.userManager = userManager;
            this.appSettings = appSettings.Value;
        }


        public async Task<object> CreateUser(RegisterModel model)
        {
            var appUser = new AppUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName
            };

            var result = await userManager.CreateAsync(appUser, model.Password);
            return (result);
        }

        public async Task<AppUser> FindUserByName(LoginModel model)
        {
            return(await userManager.FindByNameAsync(model.UserName));
        }

        public async Task<AppUser> FindUserById(string userId)
        {
            return (await userManager.FindByIdAsync(userId));
        }

        public async Task<bool> UserExists(LoginModel model)
        {
            var user = await FindUserByName(model);
            if (user!=null)
                return true;
            return false;
        }
        public async Task<bool> LoginValid(LoginModel model)
        {
            var user = await FindUserByName(model);
            return (await userManager.CheckPasswordAsync(user, model.Password));
        }

        public string CreateJwtToken(AppUser user)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("Id", user.Id.ToString())
                    }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(appSettings.Jwt_Secret)), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);
            return (token);
        }
    }
}