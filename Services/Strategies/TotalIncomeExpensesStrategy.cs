using Denisenko_FinanceAccounting.Models.Abstractions;
using Denisenko_FinanceAccounting.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Strategies
{
    public class TotalIncomeExpensesStrategy: IFinancialReportStrategy
    {
        public Dictionary<string, double> Calculate(IEnumerable<IOperation> operations, DateTime start, DateTime end)
        {
            double income = operations
                .Where(operation => operation.OperationType == "Income" && operation.Date >= start && operation.Date <= end)
                .Sum(operation => operation.Amount);

            double expenses = operations
                .Where(operation => operation.OperationType == "Expense" && operation.Date >= start && operation.Date <= end)
                .Sum(operation => operation.Amount);

            return new Dictionary<string, double>()
            {
                { "Income", income },
                { "Expenses", expenses }
            };
        }

    }
}
