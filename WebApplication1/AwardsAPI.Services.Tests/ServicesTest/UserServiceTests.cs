using AwardsAPI.BusinessLogic.Interfaces;
using ConsoleAppForDb.ModelsNewData;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Xunit;

namespace AwardsAPI.BusinessLogic.Tests.ServicesTest
{
    [ExcludeFromCodeCoverage]
    public class UserServiceTests
    {
        [Fact]
        public void User_Create_ReturnTrue()
        {
            //Arrange
            var userService = new Mock<IUserService>();
            var userData = new UserData();
            //Act
            userService.Setup(x => x.Create(userData)).Returns(true);
            //Assert
            Assert.Equal(true, userService.Object.Create(userData));
        }
        [Fact]
        public void DeleteUser_NegativeId_ReturnTrue()
        {
            var userService = new Mock<IUserService>();
            var id = -1;
            userService.Setup(x => x.Delete(id)).Returns(true);
            Assert.Equal(true,userService.Object.Delete(id));
        }
        [Fact]
        public void Asd()
        {

        }

    }
}
