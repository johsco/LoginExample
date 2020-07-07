using System.Threading.Tasks;
using LoginExample.Interfaces.Managers;
using LoginExample.Interfaces.Repositories;
using LoginExample.Models;

namespace LoginExample.Managers
{
    public class UserManager: IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public  Task<bool> LoginUserAsync(UserLoginRequest loginRequest)
        {
            return _userRepository.LoginUserAsync(loginRequest);
        }
    }
}