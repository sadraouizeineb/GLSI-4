using Microsoft.AspNetCore.Identity;

namespace AuthAPI.IServices
{
    public interface IUserService
    {
        IEnumerable<IdentityUser> GetUsersList();
    }
}
