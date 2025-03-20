using Denisenko_FinanceAccounting.Models.Abstractions;
using Denisenko_FinanceAccounting.Models;
using Denisenko_FinanceAccounting.Services.Abstractions;
using Denisenko_FinanceAccounting.Services.Facades;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAccounting.Tests
{
    public class OperationFacadeTests
    {
        [Fact]
        public void Add_ShouldWorkProperly()
        {
            // Arrange
            var moqCategoryLimitObservable = Substitute.For<ICategoryLimitObservable>();
            var operationFacade = new CategoryFacade(moqCategoryLimitObservable);
            var moqOperation = Substitute.For<ICategory>();

            // Act
            operationFacade.Add(moqOperation);
            int size = operationFacade.GetAll().Count();

            // Assert
            Assert.Equal(1, size);
        }

        [Fact]
        public void Remove_ShouldWorkProperly()
        {
            // Arrange
            var moqCategoryLimitObservable = Substitute.For<ICategoryLimitObservable>();
            var operationFacade = new OperationFacade(moqCategoryLimitObservable);
            var operation = new Operation(1, 100, Substitute.For<ICategory>(), Substitute.For<IBankAccount>());

            // Act
            operationFacade.Add(operation);
            operationFacade.Delete(1);
            int size = operationFacade.GetAll().Count();

            // Assert
            Assert.Equal(0, size);
        }

        [Fact]
        public void Edit_ShouldWorkProperly()
        {
            // Arrange
            var moqCategoryLimitObservable = Substitute.For<ICategoryLimitObservable>();
            var operationFacade = new OperationFacade(moqCategoryLimitObservable);

            var category = new Category(2, "Food", "Expense");
            var bankAccount = new BankAccount(1, "Test");
            DateTime dateTime = DateTime.Now;
            string description = "My first operation";
            var operation = new Operation(4, 300, category, bankAccount, dateTime, description);

            // Act
            operationFacade.Add(operation);
            operationFacade.Edit(4, "None");

            // Assert
            Assert.Equal("None", operationFacade.Get(4).Description);
        }
    }
}
