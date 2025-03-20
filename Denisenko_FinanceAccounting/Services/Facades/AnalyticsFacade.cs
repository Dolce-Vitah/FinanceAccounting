using Denisenko_FinanceAccounting.Models.Abstractions;
using Denisenko_FinanceAccounting.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Facades
{
    public class AnalyticsFacade
    {
        private IFinancialReportStrategy financialReportStrategy;

        public AnalyticsFacade(IFinancialReportStrategy financialReportStrategy)
        {
            this.financialReportStrategy = financialReportStrategy;
        }

        public void SetStrategy(IFinancialReportStrategy newStrategy)
        {
            financialReportStrategy = newStrategy;
        }

        public Dictionary<string, double> GenerateReport(IEnumerable<IOperation> operations, DateTime start, DateTime end)
        {
            return financialReportStrategy.Calculate(operations, start, end);
        }
    }
}
