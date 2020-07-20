using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using FluentAssertions;
using LoginExample.Interfaces.Repositories;
using LoginExample.Managers;
using LoginExample.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LoginExample.Tests.UnitTests.Managers
{
    [TestClass]
    public class UserManagerShould
    {
        private Mock<IUserRepository> _userRepository;
        private UserManager _userManager;

        [TestInitialize]
        public void Init()
        {
            _userRepository = new Mock<IUserRepository>();
            _userManager = new UserManager(_userRepository.Object);
        }

        [TestMethod]
        public async Task ReturnTrue()
        {
            //Arrange
            var request = new UserLoginRequest { UserName = "TestUser", Password = "Pass" };
            _userRepository.Setup(x => x.LoginUserAsync(request)).ReturnsAsync(true);
            

            //Act
            var result = await _userManager.LoginUserAsync(request);

            //Assert
            result.Should().BeTrue();
            _userRepository.Verify(x => x.LoginUserAsync(request), Times.Once);
        }

        [TestMethod]
        public async Task ThrowInvalidUserException()
        {
            //Arrange
            var request = new UserLoginRequest { UserName = "InvalidUser", Password = "Pass" };

            //Act
            try
            {
                var result = await _userManager.LoginUserAsync(request);

                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception ex)
            { 
                //Assert
                ex.Should().BeOfType<ArgumentException>();
                (ex as ArgumentException).Message.Should().Be("invalid username");

                _userRepository.Verify(x => x.LoginUserAsync(It.IsAny<UserLoginRequest>()), Times.Never);
            }
            
        }
    }
}