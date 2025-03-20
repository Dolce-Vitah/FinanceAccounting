using Denisenko_FinanceAccounting.Models.Abstractions;
using Denisenko_FinanceAccounting.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Strategies
{
    public class TopExpensesStrategy: IFinancialReportStrategy
    {
        private int topCount = 5;

        public TopExpensesStrategy() { }                

        public Dictionary<string, double> Calculate(IEnumerable<IOperation> operations, DateTime start, DateTime end)
        {
            return operations
                .Where(operation => operation.Date >= start && operation.Date <= end && operation.OperationType == "Expense")
                .OrderByDescending(operation => operation.Amount)
                .Take(topCount)
                .ToDictionary(operation => $"{operation.Date.ToShortDateString()} - {operation.CategoryId.Name}", operation => operation.Amount);
        }

    }
}
