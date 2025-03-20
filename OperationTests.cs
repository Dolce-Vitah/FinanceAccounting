using Denisenko_FinanceAccounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAccounting.Tests
{
    public class OperationTests
    {
        [Fact]
        public void ID_ShouldReturnExpectedValue()
        {
            // Arrange
            var category = new Category(2, "Food", "Expense");
            var bankAccount = new BankAccount(1, "Test");
            var operation = new Operation(4, 100, category, bankAccount);

            // Act & Assert
            Assert.Equal(4, operation.ID);
        }

        [Fact]
        public void Amount_ShouldReturnExpectedValue()
        {
            // Arrange
            var category = new Category(2, "Food", "Expense");
            var bankAccount = new BankAccount(1, "Test");
            var operation = new Operation(4, 300, category, bankAccount);

            // Act & Assert
            Assert.Equal(300, operation.Amount);
        }

        [Fact]
        public void Category_ShouldReturnExpectedValue()
        {
            // Arrange
            var category = new Category(2, "Food", "Expense");
            var bankAccount = new BankAccount(1, "Test");
            var operation = new Operation(4, 300, category, bankAccount);

            // Act & Assert
            Assert.Equal(category, operation.CategoryId);
        }

        [Fact]
        public void BankAccount_ShouldReturnExpectedValue()
        {
            // Arrange
            var category = new Category(2, "Food", "Expense");
            var bankAccount = new BankAccount(1, "Test");
            var operation = new Operation(4, 300, category, bankAccount);

            // Act & Assert
            Assert.Equal(bankAccount, operation.BankAccountId);
        }

        [Fact]
        public void Date_ShouldReturnExpectedValue()
        {
            // Arrange
            var category = new Category(2, "Food", "Expense");
            var bankAccount = new BankAccount(1, "Test");
            DateTime dateTime = DateTime.Now;
            var operation = new Operation(4, 300, category, bankAccount, dateTime);

            // Act & Assert
            Assert.Equal(dateTime, operation.Date);
        }

        [Fact]
        public void Description_ShouldReturnExpectedValue()
        {
            // Arrange
            var category = new Category(2, "Food", "Expense");
            var bankAccount = new BankAccount(1, "Test");
            DateTime dateTime = DateTime.Now;
            string description = "My first operation";
            var operation = new Operation(4, 300, category, bankAccount, dateTime, description);

            // Act & Assert
            Assert.Equal(description, operation.Description);
        }

        [Fact]
        public void Types_Equal()
        {
            // Arrange
            var category = new Category(2, "Salary", "Income");
            var bankAccount = new BankAccount(1, "Test");
            DateTime dateTime = DateTime.Now;
            string description = "My first operation";
            var operation = new Operation(4, 3000, category, bankAccount, dateTime, description);

            // Act & Assert
            Assert.True(operation.OperationType == category.CategoryType);
        }
    }
}
