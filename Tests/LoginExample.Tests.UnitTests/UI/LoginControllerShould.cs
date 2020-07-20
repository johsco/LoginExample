using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Castle.Core.Logging;
using FluentAssertions;
using LoginExample.Controllers;
using LoginExample.Interfaces.Managers;
using LoginExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LoginExample.Tests.UnitTests.UI
{
    [TestClass]
    public class LoginControllerShould
    {
        private Mock<IUserManager> _userManager;
        private LoginController _controller;
        private Mock<HttpContext> _httpContext;
        private Mock<ISession> _session;

        [TestInitialize]
        public void Init()
        {
            _userManager = new Mock<IUserManager>();
            _httpContext = new Mock<HttpContext>();
            _session = new Mock<ISession>();

            _controller = new LoginController(_userManager.Object);
            var context = new ControllerContext();
            context.HttpContext = _httpContext.Object;

            _httpContext.Setup(x => x.Session).Returns(_session.Object);

            _controller.ControllerContext = context;
        }

        [TestMethod]
        public void ReturnIndex()
        {
            //Arrange

            //Act
            var results = _controller.Index() as ViewResult;

            //Assert
            results.ViewName.Should().BeNull();
        }

        [TestMethod]
        public void UserName_RedirectsToPassword()
        {
            //Arrange
            var request = new UserLoginRequest();

            //Act
            var results = _controller.UserName(request) as RedirectToActionResult;

            //Assert
            results.ActionName.Should().Be("Password");
        }

        [TestMethod]
        public void Password_ReturnsViewResult()
        {
            //Arrange
            var request = new UserLoginRequest();
            //Act
            var results = _controller.Password(request) as ViewResult;

            //Assert
            results.ViewName.Should().BeNull();
        }

        [TestMethod]
        public async Task Login_ShouldLoginUser()
        {
            //Arrange
            var request = new UserLoginRequest
            {
                UserName = "foo"
            };

            _userManager.Setup(x => x.LoginUserAsync(request)).ReturnsAsync(true);
            
            //Act
            var results = await _controller.Login(request) as RedirectToActionResult;
           
            //Assert
            results.ControllerName.Should().Be("Home");
            results.ActionName.Should().Be("Index");
        }

        [TestMethod]
        public async Task Login_ShouldNotLoginUser()
        {
            //Arrange
            var request = new UserLoginRequest
            {
                UserName = "foo"
            };

            _userManager.Setup(x => x.LoginUserAsync(request)).ReturnsAsync(false);

            //Act
            var results = await _controller.Login(request) as RedirectToActionResult;

            //Assert
            results.ControllerName.Should().BeNull();
            results.ActionName.Should().Be("Index");
        }

    }
}