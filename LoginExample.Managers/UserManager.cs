using System;
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
            if (loginRequest.UserName != "TestUser")
            {
                throw new ArgumentException("invalid username");
            }

            return _userRepository.LoginUserAsync(loginRequest);
        }
    }
}