using Denisenko_FinanceAccounting.Models.Abstractions;
using Denisenko_FinanceAccounting.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Strategies
{
    public class CategoryGroupingStrategy: IFinancialReportStrategy
    {
        public Dictionary<string, double> Calculate(IEnumerable<IOperation> operations, DateTime start, DateTime end)
        {
            return operations
                .Where(operation => operation.Date >= start && operation.Date <= end)
                .GroupBy(operation => operation.CategoryId.Name)
                .ToDictionary(group => group.Key, group => group.Sum(operation => operation.Amount));
        }
    }
}
