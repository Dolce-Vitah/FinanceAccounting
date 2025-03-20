using Denisenko_FinanceAccounting.Services.Facades;
using Denisenko_FinanceAccounting.Services.Strategies;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Denisenko_FinanceAccounting.Services.Menu
{
    public class MainMenu: IMenu
    {
        public void Show(MenuManager menuManager)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("=== Financial Management System ===");
                    Console.WriteLine("1. Manage Categories");
                    Console.WriteLine("2. Manage Accounts");
                    Console.WriteLine("3. Manage Operations");
                    Console.WriteLine("4. Financial Analytics");
                    Console.WriteLine("5. Set Category Limits");
                    Console.WriteLine("6. Exit");
                    Console.Write("Choose an option: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1": menuManager.PushMenu(new CategoriesMenu()); break;
                        case "2": menuManager.PushMenu(new BankAccountMenu()); break;
                        case "3": menuManager.PushMenu(new OperationMenu()); break;
                        case "4": menuManager.PushMenu(new FinancialAnalyticsMenu()); break;
                        case "5": menuManager.PushMenu(new CategoryLimitsMenu()); break;
                        case "6":
                            menuManager.ClearStack();
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid option! Press any key to continue...");
                            Console.ReadKey();
                            break;
                    }
                } catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }                               
            }
        }
    }
}
