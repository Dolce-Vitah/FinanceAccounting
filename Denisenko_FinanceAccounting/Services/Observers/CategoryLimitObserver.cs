using Denisenko_FinanceAccounting.Models.Abstractions;
using Denisenko_FinanceAccounting.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Notifiers
{
    public class CategoryLimitObserver: ICategoryLimitObserver
    {
        private readonly ICategoryLimitObservable observable;

        public CategoryLimitObserver(ICategoryLimitObservable obs)
        {
            observable = obs;
            observable.AddObserver(this);
        }

        public void OnLimitExceededUpdate(ICategory category, double limit, double currentAmount)
        {
            if (currentAmount > limit)
            {
                Console.WriteLine($"Warning: Limit for {category.Name} exceeded! Limit {limit}, current amount: {currentAmount}\n");
            }
        }

        public void StopObservation()
        {
            observable.RemoveObserver(this);
        }
    }
}
