using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using ProductApp.BLL.Models;
using ProductApp.DAL.Entities;

namespace ProductApp.BLL.Services
{
    public interface IAuthService
    {
        Task<string> ValidUserLogin(LoginModel model);
        Task<IdentityResult> CreateUser(RegisterModel model);
        Task<AppUser> FindUserByName(LoginModel model);
        Task<AppUser> FindUserById(string userId);
        Task<bool> UserExists(LoginModel model);
        Task<bool> IsLoginValid(LoginModel model);
        string CreateJwtToken(AppUser user);
    }
}
