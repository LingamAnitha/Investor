using System;
using Xunit;
using Investor.Api.Repository;
using Moq;
using Investor.Api.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Investor.Api.Entities;
using FluentAssertions;
using Investor.Api.Dtos;

namespace InvestorApi.UnitTests
{
    public class AccountControllerTests
    {
        private readonly Mock<IInMemRepository> repositoryStub = new();
        private readonly Random rand = new();

        [Fact]
        public async Task GetAccountAsync_WithExistingItem_ReturnsExpectedItem()
        {
            // Arrange
            Account expectedAccount = CreateRandomItem();

            repositoryStub.Setup(repo => repo.GetAccountAsync(It.IsAny<Guid>()))
                .ReturnsAsync(expectedAccount);

            var controller = new AccountController(repositoryStub.Object);

            // Act
            var result = await controller.GetAccountAsync(Guid.NewGuid());

            // Assert
            result.Value.Should().BeEquivalentTo(expectedAccount);
        }


        [Fact]
        public async Task CreateAccountAsync_WithItemToCreate_ReturnsCreatedItem()
        {
            // Arrange
            var itemToCreate = new CreateAccountDto(
                Guid.NewGuid().ToString(),              
                rand.Next(1000));

            var controller = new AccountController(repositoryStub.Object);

            // Act
            var result = await controller.CreateAccountAsync(itemToCreate);

            // Assert
            var createdAccount = (result.Result as CreatedAtActionResult).Value as AccountDto;
            itemToCreate.Should().BeEquivalentTo(
                createdAccount,
                options => options.ComparingByMembers<AccountDto>().ExcludingMissingMembers()
            );
            createdAccount.AccountNumber.Should().NotBeEmpty();          
        }

        private Account CreateRandomItem()
        {
            return new()
            {
                AccountNumber = Guid.NewGuid(),
                AccountName = Guid.NewGuid().ToString(),
                Deposit = rand.Next(1000)
            };
        }

    }
}
