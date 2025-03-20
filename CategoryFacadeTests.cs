using Denisenko_FinanceAccounting.Models.Abstractions;
using Denisenko_FinanceAccounting.Models;
using Denisenko_FinanceAccounting.Services.Facades;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Denisenko_FinanceAccounting.Services.Abstractions;
using Denisenko_FinanceAccounting.Services.Observers;

namespace FinanceAccounting.Tests
{
    public class CategoryFacadeTests
    {
        [Fact]
        public void Add_ShouldWorkProperly()
        {
            // Arrange
            var moqCategoryLimitObservable = Substitute.For<ICategoryLimitObservable>();
            var categoryFacade = new CategoryFacade(moqCategoryLimitObservable);
            var moqCategory = Substitute.For<ICategory>();

            // Act
            categoryFacade.Add(moqCategory);
            int size = categoryFacade.GetAll().Count();

            // Assert
            Assert.Equal(1, size);
        }

        [Fact]
        public void Remove_ShouldWorkProperly()
        {
            // Arrange
            var moqCategoryLimitObservable = Substitute.For<ICategoryLimitObservable>();
            var categoryFacade = new CategoryFacade(moqCategoryLimitObservable);
            var category = new Category(1, "name", "Expense");

            // Act
            categoryFacade.Add(category);
            categoryFacade.Delete(1);
            int size = categoryFacade.GetAll().Count();

            // Assert
            Assert.Equal(0, size);
        }

        [Fact]
        public void Edit_ShouldWorkProperly()
        {
            // Arrange
            var moqCategoryLimitObservable = Substitute.For<ICategoryLimitObservable>();
            var categoryFacade = new CategoryFacade(moqCategoryLimitObservable);
            var category = new Category(1, "name", "Expense");

            // Act
            categoryFacade.Add(category);
            categoryFacade.Edit(1, "food");

            // Assert
            Assert.Equal("food", categoryFacade.Get(1).Name);
        }

        [Fact]
        public void SetLimit_ActsProperly()
        {
            // Arrange
            var observable = new CategoryLimitObservable();
            var categoryFacade = new CategoryFacade(observable);
            var category = new Category(1, "name", "Income");

            // Act
            categoryFacade.Add(category);
            categoryFacade.SetLimit(1, 100);

            // Assert
            Assert.Equal(100, observable.limits[category]);
        }

        [Fact]
        public void RemoveLimit_ActsProperly()
        {
            // Arrange
            var observable = new CategoryLimitObservable();
            var categoryFacade = new CategoryFacade(observable);
            var category1 = new Category(1, "name", "Income");
            var category2 = new Category(2, "surname", "Expense");

            // Act
            categoryFacade.Add(category1);
            categoryFacade.Add(category2);
            categoryFacade.SetLimit(1, 100);
            categoryFacade.SetLimit(2, 50);
            categoryFacade.RemoveLimit(1);

            // Assert
            Assert.Equal(1, observable.limits.Count);
        }
    }
}
