using AwardsAPI.BusinessLogic.Interfaces;
using AwardsAPI.BusinessLogic.Services;
using ConsoleAppForDb.Models;
using ConsoleAppForDb.ModelsNewData;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using WebApplication1.Interfaces;
using Xunit;

namespace AwardsAPI.BusinessLogic.Tests.ServicesTest
{
    [ExcludeFromCodeCoverage]
    public class UserServiceTests
    {
        [Fact]
        public void CreateUser_UserFieldsAreValid_ReturnSuccess()
        {
            //Arrange
            var repository = new Mock<IRepository<User>>();
            //var userServiceMock = new Mock<IUserService>();
            var userService = new UserService(repository.Object);
            var user = new User() { FirstName = "Al", LastName = "Ptr", Email = "email1", Phone = "email2" };
            var userToAdd = new UserData
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone
            };

            //Act
            var result = userService.Create(userToAdd);
            //Assert
            //result.ShouldSatisfyAllConditions();
            result.ShouldBeTrue();
        }
        [Fact]
        public void UpdateUser_UserFieldsAreValidIdIsNegative_ReturnError()
        {

            //Arrange
            var repository = new Mock<IRepository<User>>();
            var userService = new UserService(repository.Object);
            int id = 1;
            var user = new User() { FirstName = "Al", LastName = "Ptr", Email = "email1", Phone = "email2" };
            var userToUpdate = new UserData
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone
            };
            //Act
            var result = userService.Update(userToUpdate, id);
            //Assert
            //result.ShouldSatisfyAllConditions();
            result.ShouldBeTrue();
        }

    }
}
