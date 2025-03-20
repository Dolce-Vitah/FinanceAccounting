using Denisenko_FinanceAccounting.Models;
using Xunit;

namespace FinanceAccounting.Tests
{
    public class BankAccountTests
    {
        [Fact]
        public void ID_ShouldReturnExpectedValue()
        {
            // Arrange
            var bankAccount = new BankAccount(1, "Test");

            // Act & Assert
            Assert.Equal(1, bankAccount.ID);
        }

        [Fact]
        public void Name_ShouldReturnExpectedValue()
        {
            // Arrange
            var bankAccount = new BankAccount(1, "Test");

            // Act & Assert
            Assert.Equal("Test", bankAccount.Name);
        }

        [Fact]
        public void Balance_ShouldReturnZero()
        {
            // Arrange
            var bankAccount = new BankAccount(1, "Test");

            // Act & Assert
            Assert.Equal(0, bankAccount.Balance);
        }

        [Fact]
        public void Balance_ShouldReturnExpectedValue()
        {
            // Arrange
            var bankAccount = new BankAccount(1, "Test");

            // Act
            bankAccount.UpdateBalance(100);

            // Assert
            Assert.Equal(100, bankAccount.Balance);
        }

    }
}