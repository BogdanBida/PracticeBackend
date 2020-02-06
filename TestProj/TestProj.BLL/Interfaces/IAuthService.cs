using System.Threading.Tasks;
using TestProj.BLL.Models;
using TestProj.DAL.Entities;

namespace TestProj.BLL.Services
{
    public interface IAuthService
    {
        Task<object> CreateUser(RegisterModel model);
        Task<AppUser> FindUserByName(LoginModel model);
        Task<AppUser> FindUserById(string userId);
        Task<bool> UserExists(LoginModel model);
        Task<bool> LoginValid(LoginModel model);
        string CreateJwtToken(AppUser user);
    }
}
