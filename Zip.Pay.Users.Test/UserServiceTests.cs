using NUnit.Framework;
using Moq;
using System.Threading.Tasks;
using System.Linq;
using Zip.Pay.Users.Repository.Repositories;
using Zip.Pay.Users.Model;
using System.Collections.Generic;
using Zip.Pay.Users.Service.Services;
using System.Linq.Expressions;
using System;

namespace Zip.Pay.Users.Test
{
    [TestFixture]
    public class UserServiceTests
    {
        public UserService UserService { get; set; }
        public UserServiceTests()
        {
            //Arrange
            var mockUserRepository = new Mock<IUserRepository>();
            var mockAccountService = new Mock<IAccountService>();

            mockUserRepository
                .Setup(moq => moq.Find(It.IsAny<Expression<Func<Zip.Pay.Users.Repository.Model.User, bool>>>()))
                .ReturnsAsync(new List<Zip.Pay.Users.Repository.Model.User>() { new Users.Repository.Model.User() { Id = 1, Name = "Jasmine", Email = "jaskhundal@gmail.com" } }.AsQueryable());

            mockUserRepository
                .Setup(moq => moq.GetAll())
                .ReturnsAsync(new List<Zip.Pay.Users.Repository.Model.User>() { new Users.Repository.Model.User() { Id = 1, Name = "Jasmine", Email = "jaskhundal@gmail.com" } }.AsQueryable());

            mockUserRepository
                .Setup(moq => moq.Add(It.IsAny<Zip.Pay.Users.Repository.Model.User>()));


            UserService = new UserService(mockUserRepository.Object, mockAccountService.Object);
        }

        [Test]
        public async Task UserService_Find_HasUser()
        {
            // Arrange

            string email = "jaskhundak@gmail.com";
            // Act
            var users = await UserService.Find(email);

            // Assert
            Assert.That(users.Count(), Is.EqualTo(1));

        }

        [Test]
        public async Task UserService_Get_HasUser()
        {

            // Act
            var users = await UserService.Get();

            // Assert
            Assert.That(users.Count(), Is.EqualTo(1));

        }



    }
}