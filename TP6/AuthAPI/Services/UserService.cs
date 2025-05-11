using AuthAPI.IServices;
using Microsoft.AspNetCore.Identity;

namespace AuthAPI.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UserService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public IEnumerable<IdentityUser> GetUsersList()
        {
            return _userManager.Users;
        }
    }
}
