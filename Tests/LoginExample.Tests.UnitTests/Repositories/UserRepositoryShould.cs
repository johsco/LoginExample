using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using FluentAssertions;
using LoginExample.Interfaces;
using LoginExample.Interfaces.Repositories;
using LoginExample.Models;
using LoginExample.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LoginExample.Tests.UnitTests.Repositories
{
    [TestClass]
    public class UserRepositoryShould
    {
        private Mock<ISqlHelper> _sqlHelper;
        private Mock<IAppSettings> _appSettings;
        private Mock<IDataReader> _dataReader;
        private UserRepository _repository;

        [TestInitialize]
        public void Init()
        {
            _sqlHelper = new Mock<ISqlHelper>();
            _appSettings = new Mock<IAppSettings>();
            _dataReader = new Mock<IDataReader>();

            //Always want to return a SqlDataReader
            _sqlHelper.Setup(x => x.GetDataReaderAsync(It.IsAny<SqlCommand>())).ReturnsAsync(_dataReader.Object);

            _repository = new UserRepository(_appSettings.Object, _sqlHelper.Object);
        }

        [TestMethod]
        public async Task ReturnTrue()
        {
            //Arrange
            _dataReader.Setup(x => x.Read()).Returns(true);
            var request = new UserLoginRequest();

            //Act
            var results = await _repository.LoginUserAsync(request);

            //Assert
            results.Should().BeTrue();
            _sqlHelper.Verify(x => x.GetDataReaderAsync(It.IsAny<SqlCommand>()), Times.Once);
            _dataReader.Verify(x => x.Read(), Times.AtLeastOnce);
            _appSettings.Verify(x => x.LoginDb, Times.Once);
        }
    }
}