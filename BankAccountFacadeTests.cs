using Denisenko_FinanceAccounting.Models;
using Denisenko_FinanceAccounting.Models.Abstractions;
using Denisenko_FinanceAccounting.Services.Facades;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAccounting.Tests
{
    public class BankAccountFacadeTests
    {
        [Fact]
        public void Add_ShouldWorkProperly()
        {
            // Arrange
            var bankAccount = new BankAccountFacade();
            var moqAccount = Substitute.For<IBankAccount>();

            // Act
            bankAccount.Add(moqAccount);
            int size = bankAccount.GetAll().Count();

            // Assert
            Assert.Equal(1, size);
        }

        [Fact]
        public void Remove_ShouldWorkProperly()
        {
            // Arrange
            var bankAccount = new BankAccountFacade();
            var account = new BankAccount(1, "name");

            // Act
            bankAccount.Add(account);
            bankAccount.Delete(1);
            int size = bankAccount.GetAll().Count();

            // Assert
            Assert.Equal(0, size);
        }

        [Fact]
        public void Edit_ShouldWorkProperly()
        {
            // Arrange
            var bankAccount = new BankAccountFacade();
            var account = new BankAccount(1, "name");

            // Act
            bankAccount.Add(account);
            bankAccount.Edit(1, "meow");

            // Assert
            Assert.Equal("meow", bankAccount.Get(1).Name);
        }
    }
}
