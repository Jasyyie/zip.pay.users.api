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
    public class AccountServiceTests
    {
        public AccountService AccountService { get; set; }
        public AccountServiceTests()
        {
            //Arrange
            var mockAccountRepository = new Mock<IAccountRepository>();

            mockAccountRepository
                .Setup(moq => moq.GetAll())
                .ReturnsAsync(new List<Zip.Pay.Users.Repository.Model.Account>() { new Users.Repository.Model.Account() { Id = 1, UserId = 2, Credit = 10, User = new Users.Repository.Model.User() { } } }.AsQueryable());

            mockAccountRepository
                .Setup(moq => moq.Add(It.IsAny<Zip.Pay.Users.Repository.Model.Account>()));


            AccountService = new AccountService(mockAccountRepository.Object);
        }

        [Test]
        public async Task AccountService_Get_HasAccount()
        {

            // Act
            var accounts = await AccountService.Get();

            // Assert
            Assert.That(accounts.Count(), Is.EqualTo(1));

        }



    }
}