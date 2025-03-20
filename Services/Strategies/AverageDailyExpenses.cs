using Denisenko_FinanceAccounting.Models.Abstractions;
using Denisenko_FinanceAccounting.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Strategies
{
    public class AverageDailyExpenses: IFinancialReportStrategy
    {
        public Dictionary<string, double> Calculate(IEnumerable<IOperation> operations, DateTime start, DateTime end)
        {
            var totalDays = (end - start).Days + 1;
            var totalExpenses = operations
                .Where(operation => operation.Date >= start && operation.Date <= end && operation.OperationType == "Expense")
                .Sum(operation => operation.Amount);

            return new Dictionary<string, double> { { "Average daily expenses", totalExpenses / totalDays } };
        }
    }
}
