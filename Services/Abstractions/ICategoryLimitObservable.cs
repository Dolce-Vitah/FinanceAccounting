using Denisenko_FinanceAccounting.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Abstractions
{
    public interface ICategoryLimitObservable
    {
        void SetLimit(ICategory category, double limit);

        void RemoveLimit(ICategory category);

        void AddExpense(IOperation operation);

        void AddObserver(ICategoryLimitObserver observer);

        void RemoveObserver(ICategoryLimitObserver observer);
    }
}
