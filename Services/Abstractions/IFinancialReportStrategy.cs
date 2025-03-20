using Denisenko_FinanceAccounting.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Abstractions
{
    public interface IFinancialReportStrategy
    {
        Dictionary<string, double> Calculate(IEnumerable<IOperation> operations, DateTime start, DateTime end);
    }
}
