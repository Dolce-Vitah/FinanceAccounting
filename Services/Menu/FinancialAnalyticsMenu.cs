using Denisenko_FinanceAccounting.Services.Abstractions;
using Denisenko_FinanceAccounting.Services.Facades;
using Denisenko_FinanceAccounting.Services.Strategies;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Menu
{
    public class FinancialAnalyticsMenu: IMenu
    {
        public void Show(MenuManager menuManager)
        {
            var analyticsFacade = menuManager.GetService<AnalyticsFacade>();
            var categoryStrategy = menuManager.GetService<IFinancialReportStrategy>();
            var topExpensesStrategy = menuManager.GetService<TopExpensesStrategy>();
            var averageDailyExpensesStrategy = menuManager.GetService<AverageDailyExpenses>();
            var totalIncomeExpensesStrategy = menuManager.GetService<TotalIncomeExpensesStrategy>();

            var operationFacade = menuManager.GetService<IOperationFacade>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Financial Analytics ===");
                Console.WriteLine("1. View Expenses and Incomes by Category");
                Console.WriteLine("2. View Top Expenses");
                Console.WriteLine("3. View Average Daily Expenses");
                Console.WriteLine("4. View Total Income and Expenses");
                Console.WriteLine("5. Back");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        analyticsFacade.SetStrategy(categoryStrategy);
                        break;
                    case "2":
                        analyticsFacade.SetStrategy(topExpensesStrategy);
                        break;
                    case "3":
                        analyticsFacade.SetStrategy(averageDailyExpensesStrategy);
                        break;
                    case "4":
                        analyticsFacade.SetStrategy(totalIncomeExpensesStrategy);
                        break;
                    case "5": menuManager.PopMenu(); return;
                }

                var start = GetDate("start");
                var end = GetDate("end");

                var report = analyticsFacade.GenerateReport(operationFacade.GetAll(), start, end);
                foreach (var entry in report)
                    Console.WriteLine($"{entry.Key}: {entry.Value}");

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }                        
        }

        private DateTime GetDate(string addOn)
        {
            Console.Write($"Enter {addOn} date (dd.MM.yyyy): ");
            return ManageWrongDate(Console.ReadLine());
        }

        private DateTime ManageWrongDate(string date)
        {
            DateTime result;
            while (!DateTime.TryParse(date, out result))
            {
                Console.Write("Invalid date. Please enter a valid date: ");
                date = Console.ReadLine();
            }
            return result;
        }

    }
}
