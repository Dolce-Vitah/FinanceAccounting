using Denisenko_FinanceAccounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAccounting.Tests
{
    public class CategoryTests
    {
        [Fact]
        public void ID_ShouldReturnExpectedValue()
        {
            // Arrange
            var category = new Category(2, "Food", "Expense");

            // Act & Assert
            Assert.Equal(2, category.ID);
        }

        [Fact]
        public void Name_ShouldReturnExpectedValue()
        {
            // Arrange
            var category = new Category(3, "Rent", "Expense");

            // Act & Assert
            Assert.Equal("Rent", category.Name);
        }

        [Fact]
        public void Type_ShouldReturnExpectedValue()
        {
            // Arrange
            var category = new Category(3, "Rent", "Expense");

            // Act & Assert
            Assert.Equal("Expense", category.CategoryType);
        }
    }
}
