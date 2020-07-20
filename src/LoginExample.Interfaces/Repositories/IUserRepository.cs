using System.Threading.Tasks;
using LoginExample.Models;

namespace LoginExample.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> LoginUserAsync(UserLoginRequest loginRequest);
    }
}