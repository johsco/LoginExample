using System.Threading.Tasks;
using LoginExample.Models;

namespace LoginExample.Interfaces.Managers
{
    public interface IUserManager
    {
        Task<bool> LoginUserAsync(UserLoginRequest loginRequest);
    }
}