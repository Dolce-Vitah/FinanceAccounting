using Denisenko_FinanceAccounting.Models.Abstractions;
using Denisenko_FinanceAccounting.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Observers
{
    public class CategoryLimitObservable: ICategoryLimitObservable
    {
        public readonly Dictionary<ICategory, double> limits = new();
        public readonly Dictionary<ICategory, double> expenses = new();
        public readonly List<ICategoryLimitObserver> observers = new();

        public void SetLimit(ICategory category, double limit)
        {
            limits[category] = limit;
        }

        public void RemoveLimit(ICategory category)
        {
            limits.Remove(category);
        }

        public void AddExpense(IOperation operation)
        {
            if (!limits.ContainsKey(operation.CategoryId))
            {
                return;
            }

            if (!expenses.ContainsKey(operation.CategoryId))
            {
                expenses[operation.CategoryId] = 0;
            }

            expenses[operation.CategoryId] += operation.Amount;

            CheckLimits(operation.CategoryId);
        }

        public void AddObserver(ICategoryLimitObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(ICategoryLimitObserver observer)
        {
            observers.Remove(observer);
        }

        private void CheckLimits(ICategory category)
        {
            foreach (var observer in observers)
            {
                observer.OnLimitExceededUpdate(category, limits[category], expenses[category]);
            }
        }
    }
}
