using Denisenko_FinanceAccounting.Services.Abstractions;
using Denisenko_FinanceAccounting.Services.Decorators;
using Denisenko_FinanceAccounting.Services.Facades;
using Denisenko_FinanceAccounting.Services.Factories;
using Denisenko_FinanceAccounting.Services.Notifiers;
using Denisenko_FinanceAccounting.Services.Observers;
using Denisenko_FinanceAccounting.Services.Strategies;
using Denisenko_FinanceAccounting.Services.Tools;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.DI
{
    public static class DIConfig
    {
        public static ServiceProvider Configure()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IFinanceFactory, FinanceFactory>();

            services.AddSingleton<ICategoryLimitObservable, CategoryLimitObservable>();
            services.AddSingleton<ICategoryLimitObserver, CategoryLimitObserver>();

            services.AddSingleton<IFinancialReportStrategy, CategoryGroupingStrategy>();
            
            services.AddSingleton<AverageDailyExpenses>();
            services.AddSingleton<TopExpensesStrategy>();
            services.AddSingleton<TotalIncomeExpensesStrategy>();

            services.AddSingleton<IBankAccountFacade, BankAccountFacade>();
            services.AddSingleton<ICategoryFacade, CategoryFacade>();
            services.AddSingleton<IOperationFacade, OperationFacade>();
            services.AddSingleton<AnalyticsFacade>();

            services.AddSingleton<ILogger, CommandLogger>();                    

            return services.BuildServiceProvider();
        }
    }
}
