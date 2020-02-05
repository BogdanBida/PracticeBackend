using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProj.Models;

namespace TestProj.Services
{
    public interface IAuthService
    {
        Task<object> CreateUser(RegisterModel model);
        Task<AppUser> FindUser(LoginModel model);
        Task<bool> UserExists(LoginModel model);
        Task<bool> LoginValid(LoginModel model);
        string CreateJwtToken(AppUser user);
    }
}
